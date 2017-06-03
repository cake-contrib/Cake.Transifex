#load "./.build/parameters.cake"

var parameters = BuildParameters.GetParameters(Context);
var publishingError = false;

Setup(context =>
{
    parameters.Initialize(context);

    if (parameters.IsMainBranch && (context.Log.Verbosity != Verbosity.Diagnostic))
    {
        Information("Increasing verbosity to diagnostic");
        context.Log.Verbosity = Verbosity.Diagnostic;
    }

    Information("Building version {0} of Cake ({1}, {2}) using version {3} of Cake. (IsTagged: {4})",
        parameters.Version.SemVersion,
        parameters.Configuration,
        parameters.Target,
        parameters.Version.CakeVersion,
        parameters.IsTagged);
});

Task("Clean")
    .Does(() =>
{
    CleanDirectories(parameters.Paths.Directories.ToClean);
});

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    DotNetCoreRestore(parameters.Paths.Files.SolutionPath.FullPath, new DotNetCoreRestoreSettings
    {
        ArgumentCustomization = parameters.GetMsBuildArgs(Context)
    });
});

Task("Create-Release-Notes")
    .WithCriteria(() => parameters.ShouldCreateReleaseNotes)
    .WithCriteria(() => parameters.GitHub.HasCredentials)
    .Does(() =>
{
    GitReleaseManagerCreate(
        parameters.GitHub.UserName,
        parameters.GitHub.Password,
        BuildParameters.MainRepoUser,
        BuildParameters.MainRepoName,
        new GitReleaseManagerCreateSettings
        {
            Milestone = parameters.Version.Milestone,
            Name = "New Release: " + parameters.Version.Milestone,
            Prerelease = !parameters.IsMainBranch,
            TargetCommitish = BuildParameters.MainBranch
        }
    );
});

Task("Export-Release-Notes")
    .IsDependentOn("Create-Release-Notes")
    .IsDependentOn("Clean")
    .WithCriteria(() => parameters.GitHub.HasCredentials)
    .Does(() =>
{
    GitReleaseManagerExport(
        parameters.GitHub.UserName,
        parameters.GitHub.Password,
        BuildParameters.MainRepoUser,
        BuildParameters.MainRepoName,
        parameters.Paths.Files.Changelog
    );

    string[] releaseNotes;
    if (!FileExists(parameters.Paths.Files.Changelog) && !parameters.ShouldPublish)
    {
      releaseNotes = new[] { "No release notes available for this release" };
    }
    else
    {
      releaseNotes = ParseReleaseNotes(parameters.Paths.Files.Changelog).Notes.ToArray();
    }

    parameters.SetReleaseNotes(Context, releaseNotes);
});

Task("Build")
    .IsDependentOn("Export-Release-Notes")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    DotNetCoreBuild(parameters.Paths.Files.SolutionPath.FullPath, new DotNetCoreBuildSettings
    {
        VersionSuffix = parameters.Version.DotNetAsterix,
        Configuration = parameters.Configuration,
        NoDependencies = true,
        ArgumentCustomization = parameters.GetMsBuildArgs(Context)
    });
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    var projects = GetFiles("./tests/**/*.Tests.csproj");
    if (FileExists(parameters.Paths.Files.TestCoverageOutputFilePath))
    {
        DeleteFile(parameters.Paths.Files.TestCoverageOutputFilePath);
    }

    foreach (var project in projects)
    {
        Action<ICakeContext> testAction = tool =>
        {
            var settings = new DotNetCoreTestSettings
            {
                Configuration = parameters.Configuration,
                NoBuild = true,
                ArgumentCustomization = parameters.GetMsBuildArgs(Context)
            };
            if (parameters.IsRunningOnUnix)
            {
                // We are unable to test for .net 4.5(.2) because dotnet test can't find
                // the test adapter for that framework, so skipping until it is fixed.
                settings.Framework = "netcoreapp1.0";
            }
            tool.DotNetCoreTest(project.FullPath, settings);
        };

        if (parameters.IsRunningOnUnix || parameters.SkipOpenCover)
        {
            testAction(Context);
        }
        else
        {
            OpenCover(testAction,
                parameters.Paths.Files.TestCoverageOutputFilePath,
                new OpenCoverSettings
                {
                    MergeOutput = FileExists(parameters.Paths.Files.TestCoverageOutputFilePath),
                    SkipAutoProps = true,
                    Register = "user",
                    OldStyle = true
                }
                .WithFilter("+[*]* -[*Tests]* -[Cake.Transifex]TransifexRunnerAliases")
            );
        }
    }

    if (FileExists(parameters.Paths.Files.TestCoverageOutputFilePath) && parameters.IsLocalBuild)
    {
        ReportGenerator(parameters.Paths.Files.TestCoverageOutputFilePath, parameters.Paths.Directories.TestResults);
    }
});

Task("Upload-Coverage-Report")
    .WithCriteria(parameters.IsRunningOnAppVeyor)
    .Does(() =>
{
    Codecov(parameters.Paths.Files.TestCoverageOutputFilePath.ToString());
});

Task("Publish-MyGet")
    .IsDependentOn("Upload-Coverage-Report")
    .WithCriteria(() => parameters.ShouldPublishToMyGet)
    .Does(() =>
{
    var apiKey = EnvironmentVariable("MYGET_API_KEY");
    if (string.IsNullOrEmpty(apiKey))
    {
        throw new InvalidOperationException("Could not resolve MyGet API key.");
    }

    var apiUrl = EnvironmentVariable("MYGET_API_URL");
    if (string.IsNullOrEmpty(apiUrl))
    {
        throw new InvalidOperationException("Could not resolve MyGet API url.");
    }

    var symbolsUrl = EnvironmentVariable("MYGET_SYMBOLS_URL");
    if (string.IsNullOrEmpty(symbolsUrl))
    {
        throw new InvalidOperationException("Could not resolve MyGet Symbols url.");
    }

    var packages = GetFiles(parameters.Paths.Directories.NugetRoot + "/**/*.nupkg");

    foreach (var package in packages)
    {
        var settings = new NuGetPushSettings
        {
            ApiKey = apiKey
        };
        if (package.FullPath.EndsWith(".symbols.nupkg"))
        {
            settings.Source = symbolsUrl;
        }
        else
        {
            settings.Source = apiUrl;
        }

        NuGetPush(package, settings);
    }
}).OnError(exception =>
{
    Information("Publish-MyGet Task failed, but continuing with next Task...");
    publishingError = true;
});

Task("Publish-NuGet")
    .IsDependentOn("Upload-Coverage-Report")
    .WithCriteria(() => parameters.ShouldPublish)
    .Does(() =>
{
    var apiKey = EnvironmentVariable("NUGET_API_KEY");
    if (string.IsNullOrEmpty(apiKey))
    {
        throw new InvalidOperationException("Could not resolve NuGet API key.");
    }

    var apiUrl = EnvironmentVariable("NUGET_API_URL");
    if (string.IsNullOrEmpty(apiUrl))
    {
        throw new InvalidOperationException("Could not resolve NuGet API url.");
    }

    var packages = GetFiles(parameters.Paths.Directories.NugetRoot + "/**/*.nupkg");
    foreach (var package in packages)
    {
        if (!package.FullPath.EndsWith(".symbols.nupkg"))
        {
            NuGetPush(package, new NuGetPushSettings
            {
                ApiKey = apiKey,
                Source = apiUrl
            });
        }
    }
}).OnError(exception =>
{
    Information("Publish-NuGet Task failed, but continuing with next Task...");
    publishingError = true;
});

Task("Publish-GitHub-Release")
    .IsDependentOn("Upload-Coverage-Report")
    .WithCriteria(() => parameters.GitHub.HasCredentials)
    .WithCriteria(() => parameters.ShouldPublish)
    .Does(() =>
{
    GitReleaseManagerClose(
        parameters.GitHub.UserName,
        parameters.GitHub.Password,
        BuildParameters.MainRepoUser,
        BuildParameters.MainRepoName,
        parameters.Version.Milestone
    );
    GitReleaseManagerPublish(
        parameters.GitHub.UserName,
        parameters.GitHub.Password,
        BuildParameters.MainRepoUser,
        BuildParameters.MainRepoName,
        parameters.Version.Milestone
    );
});

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

Task("AppVeyor")
    .IsDependentOn("Run-Unit-Tests")
    .IsDependentOn("Upload-Coverage-Report")
    .IsDependentOn("Publish-MyGet")
    .IsDependentOn("Publish-NuGet")
    .IsDependentOn("Publish-GitHub-Release")
    .Finally(() =>
{
    if (publishingError)
    {
        throw new Exception("An error occurred during the publishing of " + BuildParameters.MainRepoName + ". All publishing tasks have been attempted.");
    }
});

Task("ReleaseNotes")
    .IsDependentOn("Create-Release-Notes");


RunTarget(parameters.Target);

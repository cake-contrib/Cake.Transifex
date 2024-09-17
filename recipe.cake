#load nuget:?package=Cake.Recipe&version=3.1.1
#load "./.build/*.cake"

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.Transifex",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.Transifex",
    appVeyorAccountName: "cakecontrib",
    shouldRunDotNetCorePack: true,
    solutionFilePath: "./Cake.Transifex.sln",
    testFilePattern: "/**/*.Tests.csproj",
    preferredBuildAgentOperatingSystem: PlatformFamily.Linux,
    preferredBuildProviderType: BuildProviderType.GitHubActions,
    shouldRunCodecov: true,
    shouldRunCoveralls: false,
    shouldUseDeterministicBuilds: true,
    shouldUseTargetFrameworkPath: false);

ToolSettings.SetToolSettings(
    context: Context,
    testCoverageExcludeByFile: "**/*Designer.cs,*/*.g.cs;**/*.g.i.cs",
    testCoverageExcludeByAttribute: "Obsolete;GeneratedCodeAttribute;CompilerGeneratedAttribute");
ToolSettings.SetToolPreprocessorDirectives(
    codecovTool: "#tool nuget:?package=CodecovUploader&version=0.5.0"
);

BuildParameters.PrintParameters(Context);

// Temporary Overrides needed to work properly with TX.Exe

((CakeTask)BuildParameters.Tasks.TransifexSetupTask.Task).Actions.Clear();
((CakeTask)BuildParameters.Tasks.TransifexPushSourceResource.Task).Actions.Clear();
((CakeTask)BuildParameters.Tasks.TransifexPullTranslations.Task).Actions.Clear();
((CakeTask)BuildParameters.Tasks.TransifexPushTranslations.Task).Actions.Clear();

private static void AddGlobalOptions(TransifexRunnerSettings settings)
{
    if (!string.IsNullOrEmpty(BuildParameters.Transifex.ApiToken))
    {
        settings.ArgumentCustomization = args => args.PrependSwitchQuotedSecret("--token", " ", BuildParameters.Transifex.ApiToken);
    };
}

BuildParameters.Tasks.TransifexPushSourceResource.Does(() =>
{
    var settings = new TransifexPushSettings
    {
        UploadSourceFiles = true,
        Force = string.Equals(BuildParameters.Target, "Transifex-Push-SourceFiles", StringComparison.OrdinalIgnoreCase),
    };

    AddGlobalOptions(settings);

    TransifexPush(settings);
});

BuildParameters.Tasks.TransifexPullTranslations.Does(() =>
{
    var settings = new TransifexPullSettings
    {
        All = true,
        Mode = BuildParameters.TransifexPullMode,
        MinimumPercentage = BuildParameters.TransifexPullPercentage
    };

    AddGlobalOptions(settings);

    TransifexPull(settings);
});

Build.RunDotNetCore();

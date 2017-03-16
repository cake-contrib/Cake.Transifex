public class BuildPaths
{
    public BuildFiles Files { get; private set; }
    public BuildDirectories Directories { get; private set; }

    public static BuildPaths GetPaths(
        ICakeContext context,
        string configuration,
        string semVersion
    )
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }

        if (string.IsNullOrEmpty(configuration))
        {
            throw new ArgumentNullException("configuration");
        }

        if (string.IsNullOrEmpty(semVersion))
        {
            throw new ArgumentNullException("semVersion");
        }

        const string AppName = "Cake.Transifex";
        var artifactsDir = (DirectoryPath)context.Directory("./artifacts/v" + semVersion);
        var testResultsDir = artifactsDir.Combine("test-results");
        var nugetRoot = artifactsDir.Combine("nuget");

        var testCoverageOutputFilePath = testResultsDir.CombineWithFilePath("coverage-result.xml");

        var projects = new DirectoryPath[]
        {
            context.Directory("./src/" + AppName),
            context.Directory("./src/" + AppName + ".Tests")
        };

        var buildDirectories = new BuildDirectories(
            artifactsDir,
            nugetRoot,
            testResultsDir,
            projects
        );

        var buildFiles = new BuildFiles(
            testCoverageOutputFilePath,
            "./" + AppName + ".sln",
            artifactsDir.CombineWithFilePath("CHANGELOG.md")
        );

        return new BuildPaths
        {
            Files = buildFiles,
            Directories = buildDirectories
        };
    }
}

public class BuildFiles
{
    public FilePath TestCoverageOutputFilePath { get; private set; }
    public FilePath SolutionPath { get; private set; }
    public FilePath Changelog { get; private set; }

    public BuildFiles(
        FilePath testCoverageOutputFilePath,
        FilePath solutionPath,
        FilePath changelogPath
    )
    {
        TestCoverageOutputFilePath = testCoverageOutputFilePath;
        SolutionPath = solutionPath;
        Changelog = changelogPath;
    }
}

public class BuildDirectories
{
    public DirectoryPath Artifacts { get; private set; }
    public DirectoryPath NugetRoot { get; private set; }
    public DirectoryPath TestResults { get; private set; }
    public ICollection<DirectoryPath> ToClean { get; private set; }

    public BuildDirectories(
        DirectoryPath artifactsDir,
        DirectoryPath nugetRoot,
        DirectoryPath testResultsDir,
        ICollection<DirectoryPath> projects
    )
    {
        Artifacts = artifactsDir;
        NugetRoot = nugetRoot;
        TestResults = testResultsDir;

        ToClean = new[]
        {
            Artifacts,
            TestResults
        }.Concat(projects.Select(p => p.Combine("bin")))
         .Concat(projects.Select(p => p.Combine("obj"))).ToArray();
    }
}

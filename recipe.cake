#load nuget:?package=Cake.Recipe&version=3.0.1
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

ToolSettings.SetToolSettings(context: Context);
ToolSettings.SetToolPreprocessorDirectives(
    codecovTool: "#tool nuget:?package=CodecovUploader&version=0.5.0"
);

BuildParameters.PrintParameters(Context);

((CakeTask)BuildParameters.Tasks.TransifexSetupTask.Task).Actions.Clear();

Build.RunDotNetCore();

#load nuget:?package=Cake.Recipe&version=2.1.0
#load "./.build/*.cake"

Environment.SetVariableNames();

var platform = PlatformFamily.Linux;
var provider = BuildProviderType.GitHubActions;

// Because GitVersion do not play nice with GitHub Action, we need to do the publishing
// on appveyor instead
if (HasEnvironmentVariable("APPVEYOR") && EnvironmentVariable("APPVEYOR_REPO_TAG", false))
{
    platform = PlatformFamily.Windows;
    provider = BuildProviderType.AppVeyor;
}

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
    shouldRunCodecov: true,
    shouldRunCoveralls: false,
    shouldUseDeterministicBuilds: true,
    shouldUseTargetFrameworkPath: false,
    preferredBuildAgentOperatingSystem: platform,
    preferredBuildProviderType: provider);

ToolSettings.SetToolSettings(context: Context);

BuildParameters.PrintParameters(Context);

Build.RunDotNetCore();

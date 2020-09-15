#load nuget:https://ci.appveyor.com/nuget/cake-recipe?package=Cake.Recipe&version=2.0.0-alpha0462&prerelease
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
    shouldRunCodecov: true,
    shouldRunCoveralls: false,
    shouldUseDeterministicBuilds: true,
    shouldUseTargetFrameworkPath: false,
    preferredBuildAgentOperatingSystem: PlatformFamily.Linux,
    preferredBuildProviderType: BuildProviderType.GitHubActions);

ToolSettings.SetToolSettings(context: Context);

BuildParameters.PrintParameters(Context);

Build.RunDotNetCore();

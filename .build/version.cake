public class BuildVersion
{
    public string Version { get; private set; }
    public string SemVersion { get; private set; }
    public string FullSemVersion { get; private set; }
    public string DotNetAsterix { get; private set; }
    public string Milestone { get; private set; }
    public string CakeVersion { get; private set; }

    public static BuildVersion Calculate(ICakeContext context, BuildParameters parameters)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }

        string version = "0.0.0",
               semVersion = version + "-unknown",
               milestone = string.Concat("v", version),
               fullSemVersion = semVersion;

        try
        {
            if (!parameters.SkipGitVersion)
            {
                if (!parameters.IsLocalBuild || parameters.IsPublishBuild || parameters.IsReleaseBuild)
                {
                    context.GitVersion(new GitVersionSettings
                    {
                        OutputType = GitVersionOutput.BuildServer
                    });
                }

                var assertedVersion = context.GitVersion(new GitVersionSettings
                {
                    OutputType = GitVersionOutput.Json
                });

                version = assertedVersion.MajorMinorPatch;
                semVersion = assertedVersion.LegacySemVerPadded;
                milestone = string.Concat("v", version);
                fullSemVersion = assertedVersion.FullSemVer;

                context.Information("Calculated Semantic Version: {0}", semVersion);
            }
        }
        catch
        {
            context.Warning("Unable to calculate Semantic Version, Setting version to '0.0.0-unknown'");
        }

        return new BuildVersion
        {
            Version = version,
            SemVersion = semVersion,
            DotNetAsterix = semVersion.Substring(version.Length).TrimStart('-'),
            Milestone = milestone,
            CakeVersion = typeof(ICakeContext).Assembly.GetName().Version.ToString(),
            FullSemVersion = fullSemVersion
        };
    }
}

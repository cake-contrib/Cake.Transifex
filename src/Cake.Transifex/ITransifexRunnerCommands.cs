namespace Cake.Transifex
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the commands supported by the transifex client and the transifex runner.
    /// </summary>
    public interface ITransifexRunnerCommands
    {
        /// <summary>
        /// Pull files from remote server to local repository.
        /// </summary>
        /// <param name="settings">The settings to use when pulling resources from the server.</param>
        /// <returns>The current instance of <see cref="ITransifexRunnerCommands"/>.</returns>
        ITransifexRunnerCommands Pull(TransifexPullSettings settings = null);

        /// <summary>
        /// Push local files to remote server.
        /// </summary>
        /// <param name="settings">The settings to use when pushing resources to the server.</param>
        /// <returns>The current instance of <see cref="ITransifexRunnerCommands"/>.</returns>
        ITransifexRunnerCommands Push(TransifexPushSettings settings = null);

        /// <summary>
        /// Print status of current project.
        /// </summary>
        /// <param name="resources">The resources to check the status for (defaults to all).</param>
        /// <returns>The current instance of <see cref="ITransifexRunnerCommands"/>.</returns>
        ITransifexRunnerCommands Status(string resources = null);
    }
}

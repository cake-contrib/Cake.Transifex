// <copyright file="ITransifexRunnerCommands.cs" company="Cake Contrib">
// Copyright (c) 2017-2021 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex
{
    /// <summary>
    /// Defines the commands supported by the transifex client and the transifex runner.
    /// </summary>
    public interface ITransifexRunnerCommands
    {
        /// <summary>
        /// Initializes a transifex configuration file and the user configuration file (if token, username or password is specified).
        /// </summary>
        /// <param name="settings">The settings to use when initializing the directory.</param>
        /// <returns>The current instance of <see cref="ITransifexRunnerCommands"/>.</returns>
        /// <remarks>
        /// <note type="warning">
        ///   Do not call this runner if a configuration file already exists in the repository.
        ///   You will be asked to overwrite the file, which should not be done in cases where
        ///   the file have already been configured.
        /// </note>
        /// </remarks>
        ITransifexRunnerCommands Init(TransifexInitSettings settings);

        /// <summary>
        /// Pull files from remote server to local repository.
        /// </summary>
        /// <param name="settings">The settings to use when pulling resources from the server.</param>
        /// <returns>The current instance of <see cref="ITransifexRunnerCommands"/>.</returns>
        ITransifexRunnerCommands Pull(TransifexPullSettings settings);

        /// <summary>
        /// Push local files to remote server.
        /// </summary>
        /// <param name="settings">The settings to use when pushing resources to the server.</param>
        /// <returns>The current instance of <see cref="ITransifexRunnerCommands"/>.</returns>
        ITransifexRunnerCommands Push(TransifexPushSettings settings);

        /// <summary>
        /// Print status of current project.
        /// </summary>
        /// <param name="resources">The resources to check the status for (defaults to all).</param>
        /// <returns>The current instance of <see cref="ITransifexRunnerCommands"/>.</returns>
        ITransifexRunnerCommands Status(string resources);
    }
}

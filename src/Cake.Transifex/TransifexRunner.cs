// <copyright file="TransifexRunner.cs" company="Cake Contrib">
// Copyright (c) 2017-2021 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex
{
    using System;
    using System.Collections.Generic;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// The wrapper around the transifex client. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Cake.Core.Tooling.Tool{TSettings}"/>
    /// <seealso cref="Cake.Transifex.ITransifexRunnerCommands"/>
    internal sealed class TransifexRunner : Tool<TransifexRunnerSettings>, ITransifexRunnerCommands
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        internal TransifexRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <inheritdoc/>
        public ITransifexRunnerCommands Init(TransifexInitSettings settings)
        {
            settings = settings ?? new TransifexInitSettings();
            var args = GetTransifexRunnerArguments(settings);
            Run(settings, args);
            return this;
        }

        /// <inheritdoc/>
        public ITransifexRunnerCommands Pull(TransifexPullSettings settings)
        {
            settings = settings ?? new TransifexPullSettings();
            var args = GetTransifexRunnerArguments(settings);
            Run(settings, args);
            return this;
        }

        /// <inheritdoc/>
        public ITransifexRunnerCommands Push(TransifexPushSettings settings)
        {
            settings = settings ?? new TransifexPushSettings();
            var args = GetTransifexRunnerArguments(settings);
            Run(settings, args);
            return this;
        }

        /// <inheritdoc/>
        public ITransifexRunnerCommands Status(string resources)
        {
            var settings = new TransifexStatusSettings
            {
                Resources = resources,
            };

            var args = GetTransifexRunnerArguments(settings);
            Run(settings, args);
            return this;
        }

        /// <inheritdoc/>
        protected override IEnumerable<string> GetToolExecutableNames()
            => new[]
            {
                "tx.cmd",
                "tx.exe",
                "tx",
            };

        /// <inheritdoc/>
        protected override string GetToolName()
            => Common.TransifexRunner;

        private static void AddValue(ProcessArgumentBuilder args, string key, string value)
        {
            var quote = value.IndexOfAny(new[] { ' ', '*' }) >= 0;

            if (key.StartsWith("!", StringComparison.OrdinalIgnoreCase))
            {
                if (quote)
                {
                    args.AppendSwitchQuotedSecret(key.TrimStart('!'), value);
                }
                else
                {
                    args.AppendSwitchSecret(key.TrimStart('!'), value);
                }
            }
            else
            {
                if (quote)
                {
                    args.AppendSwitchQuoted(key, value);
                }
                else
                {
                    args.AppendSwitch(key, value);
                }
            }
        }

        private static void AddValue(ProcessArgumentBuilder args, string key, bool value)
        {
            if (value)
            {
                args.Append(key);
            }
        }

        private static ProcessArgumentBuilder GetTransifexRunnerArguments(TransifexRunnerSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            args.Append(settings.Command);

            SetArguments(args, settings);
            return args;
        }

        private static void SetArguments(ProcessArgumentBuilder args, TransifexRunnerSettings settings)
        {
            foreach (var argument in settings.GetAllArguments())
            {
                switch (argument.Value)
                {
                    case bool value:
                        AddValue(args, argument.Key, value);
                        break;

                    case TransifexMode mode:
                        AddValue(args, argument.Key, mode.ToString().ToLowerInvariant());
                        break;

                    default:
                        AddValue(args, argument.Key, argument.Value?.ToString());
                        break;
                }
            }
        }
    }
}

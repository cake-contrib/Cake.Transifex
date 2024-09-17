// <copyright file="TxRunner.cs" company="Cake Contrib">
// Copyright (c) 2017-2024 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex.Runners;

using System;
using System.Collections.Generic;
using System.Linq;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Transifex.Settings;

/// <summary>
///     The wrapper around the tx client. This class cannot be inherited.
/// </summary>
/// <seealso cref="Tool{TSettings}" />
internal sealed class TxRunner : Tool<TxGlobalSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="TxRunner" />
    ///     class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    internal TxRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
        : base(fileSystem, environment, processRunner, tools)
    {
    }

    /// <summary>
    ///     Runs the tx client using the specified
    ///     <paramref name="settings" />.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <exception cref="System.ArgumentNullException">
    ///     If the passed in <paramref name="settings" /> is <c>null</c>.
    /// </exception>
    public void Run(TxGlobalSettings settings)
    {
        Expects.NotNull(settings);

        var args = GetTxRunnerArguments(settings);
        Run(settings, args);
    }

    /// <inheritdoc />
    protected override IEnumerable<string> GetToolExecutableNames()
        => new[] { "tx.exe", "tx" };

    /// <inheritdoc />
    protected override string GetToolName()
        => Common.TxRunner;

    private static void AddValue(ProcessArgumentBuilder args, string key, object value)
    {
        if (value.GetType().IsEnum)
        {
            AddValue(args, key, value.ToString().ToLowerInvariant());
        }
        else
        {
            AddValue(args, key, value.ToString());
        }
    }

    private static void AddValue(ProcessArgumentBuilder args, string key, string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            AddValue(args, key, "\"\"");
            return;
        }

        var quote = value.IndexOfAny(new[] { ' ', '*', ',' }) >= 0;

        if (key.StartsWith("!", StringComparison.OrdinalIgnoreCase))
        {
            if (quote)
            {
                _ = args.AppendSwitchQuotedSecret(key.TrimStart('!'), value);
            }
            else
            {
                _ = args.AppendSwitchSecret(key.TrimStart('!'), value);
            }
        }
        else
        {
            if (quote)
            {
                _ = args.AppendSwitchQuoted(key, value);
            }
            else
            {
                _ = args.AppendSwitch(key, value);
            }
        }
    }

    private static void AddValue(ProcessArgumentBuilder args, string key, bool value)
    {
        if (value)
        {
            _ = args.Append(key);
        }
    }

    private static ProcessArgumentBuilder GetTxRunnerArguments(TxGlobalSettings settings)
    {
        var args = new ProcessArgumentBuilder();

        SetArguments(args, settings.GetAllPrependendArguments());
        _ = args.Append(settings.Command);
        SetArguments(args, settings.GetAllAppendedArguments());

        return args;
    }

    private static void SetArguments(ProcessArgumentBuilder args, IDictionary<string, object> arguments)
    {
        foreach (var argument in arguments.Where(a => a.Value != null))
        {
            switch (argument.Value)
            {
                case bool value:
                    AddValue(args, argument.Key, value);
                    break;

                case ICollection<string> stringValue:
                    if (stringValue.Count > 0)
                    {
                        AddValue(args, argument.Key, string.Join(',', stringValue));
                    }

                    break;

                default:
                    AddValue(args, argument.Key, argument.Value);
                    break;
            }
        }
    }
}

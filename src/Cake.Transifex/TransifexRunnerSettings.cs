// <copyright file="TransifexRunnerSettings.cs" company="Cake Contrib">
// Copyright (c) 2017-2021 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Cake.Core.Tooling;

    /// <summary>
    /// Defines common properties that can be used for all commands.
    /// </summary>
    /// <typeparam name="TSettingsType">The type of settings that inherits from this class.</typeparam>
    /// <seealso cref="TransifexRunnerSettings"/>
    [SuppressMessage("StyeCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "The class only differ in the type parameter used!")]
    public class TransifexRunnerSettings<TSettingsType> : TransifexRunnerSettings
            where TSettingsType : TransifexRunnerSettings<TSettingsType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexRunnerSettings{TSettingsType}"/> class.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        protected TransifexRunnerSettings(string command)
            : base(command)
        {
        }

        /// <summary>
        /// Gets or sets the resources you want to use for this command (defaults to all).
        /// </summary>
        /// <remarks>Supports unix style wildcards.</remarks>
        public string Resources
        {
            get => GetValue<string>("--resources");
            set => SetValue("--resources", value);
        }
    }

    /// <summary>
    /// Defines common properties that can be used for all commands.
    /// </summary>
    /// <seealso cref="Cake.Core.Tooling.ToolSettings"/>
    public class TransifexRunnerSettings : ToolSettings
    {
        private readonly IDictionary<string, object> arguments = new Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexRunnerSettings"/> class.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        protected TransifexRunnerSettings(string command)
        {
            Command = command;
        }

        /// <summary>
        /// Gets the transifex command to execute.
        /// </summary>
        internal string Command { get; }

        /// <summary>
        /// Gets all the arguments that should be used when calling this command.
        /// </summary>
        /// <returns>The arguments to be used as a dictionary.</returns>
        internal virtual IDictionary<string, object> GetAllArguments()
            => arguments;

        /// <summary>
        /// Gets the stored value with the specified <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to get.</typeparam>
        /// <param name="key">The key/id of the value.</param>
        /// <returns>The stored value, or the default value of the <typeparamref name="TValue"/>.</returns>
        protected TValue GetValue<TValue>(string key)
            => GetValue(key, default(TValue));

        /// <summary>
        /// Gets the stored value with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key/id of the value.</param>
        /// <param name="defaultValue">The value to return if no value have been stored.</param>
        /// <typeparam name="TValue">The expected type the value should be in.</typeparam>
        /// <returns>The stored value, or the specified <paramref name="defaultValue"/>.</returns>
        protected TValue GetValue<TValue>(string key, TValue defaultValue)
        {
            if (arguments.TryGetValue(key, out var objValue) && objValue is TValue value)
            {
                return value;
            }

            return defaultValue;
        }

        /// <summary>
        /// Stores the specified <paramref name="value"/> with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to use when staring the <paramref name="value"/>.</param>
        /// <param name="value">The value to store.</param>
        protected void SetValue(string key, object value)
        {
            if (value is null || (value is string stringValue && string.IsNullOrWhiteSpace(stringValue)))
            {
                if (arguments.ContainsKey(key))
                {
                    arguments.Remove(key);
                }

                return;
            }

            arguments[key] = value;
        }
    }
}

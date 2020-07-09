namespace Cake.Transifex
{
    using Cake.Core.Tooling;
    using System.Collections.Generic;

    /// <summary>
    /// Defines common properties that can be used for all commands.
    /// </summary>
    /// <seealso cref="TransifexRunnerSettings"/>
    public class TransifexRunnerSettings<TSettingsType> : TransifexRunnerSettings
            where TSettingsType : TransifexRunnerSettings<TSettingsType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexRunnerSettings"/> class.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        protected TransifexRunnerSettings(string command)
            : base(command)
        {
        }

        /// <summary>
        /// The resources you want to use for this command (defaults to all)
        /// </summary>
        /// <remarks>Supports unix style wildcards</remarks>
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
        private readonly IDictionary<string, object> _arguments = new Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexRunnerSettings"/> class.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        protected TransifexRunnerSettings(string command)
        {
            Command = command;
        }

        /// <summary>
        /// The transifex command to execute.
        /// </summary>
        internal string Command { get; }

        internal virtual IDictionary<string, object> GetAllArguments()
            => _arguments;

        /// <summary>
        /// Gets the stored value with the specified <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to get</typeparam>
        /// <param name="key">The key/id of the value</param>
        /// <returns>The stored value, or the default value of the <typeparamref name="TValue"/>.</returns>
        protected TValue GetValue<TValue>(string key)
            => GetValue(key, default(TValue));

        /// <summary>
        /// Gets the stored value with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key/id of the value</param>
        /// <param name="defaultValue">The value to return if no value have been stored.</param>
        /// <returns>The stored value, or the specified <paramref name="defaultValue"/>.</returns>
        protected TValue GetValue<TValue>(string key, TValue defaultValue)
        {
            if (_arguments.TryGetValue(key, out var objValue) && objValue is TValue value)
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
                if (_arguments.ContainsKey(key))
                {
                    _arguments.Remove(key);
                }

                return;
            }

            _arguments[key] = value;
        }
    }
}

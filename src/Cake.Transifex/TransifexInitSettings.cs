namespace Cake.Transifex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the properties that can be used when calling the init command on the transifex
    /// client. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Cake.Transifex.TransifexRunnerSettings"/>
    /// <category>Initialization</category>
    public sealed class TransifexInitSettings : TransifexRunnerSettings
    {
        private const string UserNameKey = "!--user";
        private const string PasswordKey = "!--pass";
        private const string TokenKey = "!--token";

        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexInitSettings"/> class.
        /// </summary>
        public TransifexInitSettings()
            : base("init")
        {
            Host = "www.transifex.com";
        }

        /// <summary>
        /// Gets or sets the default host of the transifex client.
        /// </summary>
        /// <remarks>
        /// Defaults to <c>www.transifex.com</c> to keep the user from
        /// being prompted to specify a host when called.
        /// </remarks>
        public string Host
        {
            get => GetValue<string>("--host");
            set => SetValue("--host", value);
        }

        /// <summary>
        /// Gets or sets the password for the user when connecting to transifex.
        /// </summary>
        /// <remarks>
        /// Can not be used together with the <see cref="Token" /> parameter.
        /// </remarks>
        /// <seealso cref="Username" />
        /// <seealso cref="Token" />
        public string Password
        {
            get => GetValue<string>(PasswordKey);
            set => SetValue(PasswordKey, value);
        }

        /// <summary>
        /// Gets or sets the token to use when connecting to transifex.
        /// </summary>>
        /// <remarks>
        /// Can not be used at the same time as setting the <see cref="Username" /> or <see cref="Password" /> parameter.
        /// </remarks>
        /// <seealso cref="Username" />
        /// <seealso cref="Password" />
        public string Token
        {
            get => GetValue<string>(TokenKey);
            set => SetValue(TokenKey, value);
        }

        /// <summary>
        /// Gets or sets the username for the user when connecting to transifex.
        /// </summary>
        /// <remarks>
        /// Can not be used at the same time as setting the <see cref="Token" /> parameter.
        /// </remarks>
        /// <seealso cref="Password" />
        /// <seealso cref="Token" />
        public string Username
        {
            get => GetValue<string>(UserNameKey);
            set => SetValue(UserNameKey, value);
        }

        internal override IDictionary<string, object> GetAllArguments()
        {
            var arguments = base.GetAllArguments();
            if (arguments.ContainsKey(TokenKey) && (arguments.ContainsKey(UserNameKey) || arguments.ContainsKey(PasswordKey)))
            {
                throw new ArgumentException(Exceptions.TokenAndUsernameException);
            }

            var hasUserNameAndPassword = arguments.ContainsKey(UserNameKey) && arguments.ContainsKey(PasswordKey);

            if (!hasUserNameAndPassword)
            {
                return arguments.Where(x => x.Key != UserNameKey && x.Key != PasswordKey).ToDictionary(s => s.Key, s => s.Value);
            }
            else
            {
                return arguments;
            }
        }
    }
}

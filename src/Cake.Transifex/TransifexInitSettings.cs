namespace Cake.Transifex
{
    using System;
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Defines the properties that can be used when calling the init command on the transifex
    /// client. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Cake.Transifex.TransifexRunnerSettings"/>
    /// <category>Initialization</category>
    public sealed class TransifexInitSettings : TransifexRunnerSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexInitSettings"/> class.
        /// </summary>
        public TransifexInitSettings()
            : base("init")
        {
        }

        /// <summary>
        /// Gets or sets the default host of the transifex client.
        /// </summary>
        /// <remarks>
        /// Defaults to <c>www.transifex.com</c> to keep the user from
        /// being prompted to specify a host when called.
        /// </remarks>
        public string Host { get; set; } = "www.transifex.com";

        /// <summary>
        /// Gets or sets the password for the user when connecting to transifex.
        /// </summary>
        /// <remarks>
        /// Can not be used together with the <see cref="Token" /> parameter.
        /// </remarks>
        /// <seealso cref="Username" />
        /// <seealso cref="Token" />
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the token to use when connecting to transifex.
        /// </summary>>
        /// <remarks>
        /// Can not be used at the same time as setting the <see cref="Username" /> or <see cref="Password" /> parameter.
        /// </remarks>
        /// <seealso cref="Username" />
        /// <seealso cref="Password" />
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the username for the user when connecting to transifex.
        /// </summary>
        /// <remarks>
        /// Can not be used at the same time as setting the <see cref="Token" /> parameter.
        /// </remarks>
        /// <seealso cref="Password" />
        /// <seealso cref="Token" />
        public string Username { get; set; }

        /// <inheritdoc />
        /// <exception cref="ArgumentException">
        /// Thrown when both the <see cref="Token" /> property and either
        /// the <see cref="Username" /> or <see cref="Password" /> properties have been
        /// specified.
        /// </exception>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (!string.IsNullOrEmpty(Token) && (!string.IsNullOrEmpty(Username) || !string.IsNullOrEmpty(Password)))
            {
                throw new ArgumentException("A token can not be set at the same time as either the username or password.");
            }

            if (!string.IsNullOrEmpty(Host))
            {
                args.Append("--host").Append(Host);
            }

            if (!string.IsNullOrEmpty(Token))
            {
                args.Append("--token").AppendSecret(Token);
            }

            if (!string.IsNullOrEmpty(Username))
            {
                args.Append("--user").Append(Username);
            }

            if (!string.IsNullOrEmpty(Password))
            {
                args.Append("--pass").AppendQuotedSecret(Password);
            }
        }
    }
}

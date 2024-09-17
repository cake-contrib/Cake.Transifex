// <copyright file="TransifexStatusSettings.cs" company="Cake Contrib">
// Copyright (c) 2017-2021 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex
{
    using System;

    /// <summary>
    /// Defines the properties that can be used when calling the status command on the transifex
    /// client. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Cake.Transifex.TransifexRunnerSettings{TSettingsType}"/>
    [Obsolete("Will be removed in v4. Use TxStatusSettings instead.")]
    public sealed class TransifexStatusSettings : TransifexRunnerSettings<TransifexStatusSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexStatusSettings"/> class.
        /// </summary>
        public TransifexStatusSettings()
            : base("status")
        {
        }
    }
}

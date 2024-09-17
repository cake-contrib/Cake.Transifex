// <copyright file="TxInitSettings.cs" company="Cake Contrib">
// Copyright (c) 2017-2024 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex.Settings;

/// <summary>
///     Defines the arguments that are available when initializing
///     transifex configuration.
/// </summary>
/// <seealso cref="TxGlobalSettings" />
public sealed class TxInitSettings : TxGlobalSettings
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="TxInitSettings" /> class.
    /// </summary>
    public TxInitSettings()
        : base("init")
    {
    }
}

// <copyright file="TxStatusSettings.cs" company="Cake Contrib">
// Copyright (c) 2017-2024 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex.Settings;

using System.Collections.Generic;

/// <summary>
///     Defines the arguments available when acquiring the Transifex
///     status.
/// </summary>
/// <seealso cref="TxGlobalSettings" />
public sealed class TxStatusSettings : TxGlobalSettings
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="TxStatusSettings" /> class.
    /// </summary>
    public TxStatusSettings()
        : base("status")
    {
    }

    /// <summary>
    ///     Gets or sets the resources to get the status for.
    /// </summary>
    /// <value>The resources.</value>
    public ICollection<string> Resources
    {
        get => GetAppendedCollectionValue<string>("--resources");
        set => AppendValue("--resources", value);
    }
}

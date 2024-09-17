// <copyright file="TxGlobalSettings.cs" company="Cake Contrib">
// Copyright (c) 2017-2024 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex.Settings;

using System.Collections.Generic;

using Cake.Core.IO;
using Cake.Core.Tooling;

/// <summary>
///     Defines the arguments that are available for all commands, which
///     are usually prepended to the command.
/// </summary>
/// <seealso cref="ToolSettings" />
public abstract class TxGlobalSettings : ToolSettings
{
    private readonly IDictionary<string, object> appendArguments = new Dictionary<string, object>();
    private readonly IDictionary<string, object> prependArguments = new Dictionary<string, object>();

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="TxGlobalSettings" /> class.
    /// </summary>
    /// <param name="command">
    ///     The name of the command to execute.
    /// </param>
    protected TxGlobalSettings(string command)
    {
        Command = command;
    }

    /// <summary>
    ///     Gets or sets the certificate to use when connecting to the
    ///     host.
    /// </summary>
    /// <value>The path to the CA Certificate.</value>
    public FilePath CertificatePath
    {
        get => GetPrependValue<FilePath>("--cacert");
        set => PrependValue("--cacert", value);
    }

    /// <summary>
    ///     Gets or sets the path to the transifex resource configuration.
    /// </summary>
    /// <value>
    ///     The path to the transifex resource configuration.
    /// </value>
    public FilePath Configuration
    {
        get => GetPrependValue<FilePath>("--config");
        set => PrependValue("--config", value);
    }

    /// <summary>
    ///     Gets or sets the name of the API host.
    /// </summary>
    /// <value>The name of the API host.</value>
    public string HostName
    {
        get => GetPrependValue<string>("--hostname");
        set => PrependValue("--hostname", value);
    }

    /// <summary>
    ///     Gets or sets the path to the root configuration.
    /// </summary>
    /// <value>The path to the root configuration.</value>
    public FilePath RootConfiguration
    {
        get => GetPrependValue<FilePath>("--root-config");
        set => PrependValue("--root-config", value);
    }

    /// <summary>
    ///     Gets or sets the authorization token to use when cummunicating
    ///     with transifex.
    /// </summary>
    /// <value>The authorization token.</value>
    public string Token
    {
        get => GetPrependValue<string>("!--token");
        set => PrependValue("!--token", value);
    }

    /// <summary>
    ///     Gets or sets the name of the command to execute.
    /// </summary>
    internal string Command { get; set; }

    /// <summary>
    ///     Gets all the arguments that should be added after the command
    ///     name.
    /// </summary>
    /// <returns>The stored arguments.</returns>
    internal virtual IDictionary<string, object> GetAllAppendedArguments()
        => appendArguments;

    /// <summary>
    ///     Gets all the arguments that should be added before the command
    ///     name.
    /// </summary>
    /// <returns>The stored arguments.</returns>
    internal virtual IDictionary<string, object> GetAllPrependendArguments()
        => prependArguments;

    /// <summary>
    ///     Stores the specified <paramref name="value" /> with the
    ///     specified <paramref name="key" /> as an argument that should
    ///     be appended after the command name.
    /// </summary>
    /// <param name="key">The key/name to use for the argument.</param>
    /// <param name="value">
    ///     The value that should be part of the key.
    /// </param>
    /// <param name="allowEmptyValue">
    ///     if set to <c>true</c> allow the argument to be used without a
    ///     value.
    /// </param>
    /// <remarks>
    ///     Marking allow empty value stores empty and whitespace values,
    ///     but remove any passed null values.
    /// </remarks>
    protected void AppendValue(string key, object value, bool allowEmptyValue = false)
        => SetValue(appendArguments, key, value, allowEmptyValue);

    /// <summary>
    ///     Gets the stored value with the specified
    ///     <paramref name="key" />.
    /// </summary>
    /// <param name="key">The key/id of the value.</param>
    /// <typeparam name="TValue">
    ///     The expected type the value should be in.
    /// </typeparam>
    /// <returns>
    ///     The stored value, or the default value of a collection.
    /// </returns>
    protected ICollection<TValue> GetAppendedCollectionValue<TValue>(string key)
    {
        var collection = GetAppendedValue<ICollection<TValue>>(key);

        if (collection is null)
        {
            collection = new List<TValue>();
            AppendValue(key, collection);
        }

        return collection;
    }

    /// <summary>
    ///     Gets the stored value with the specified
    ///     <paramref name="key" />.
    /// </summary>
    /// <param name="key">The key/id of the value.</param>
    /// <param name="defaultValue">
    ///     The value to return if no value have been stored.
    /// </param>
    /// <typeparam name="TValue">
    ///     The expected type the value should be in.
    /// </typeparam>
    /// <returns>
    ///     The stored value, or the specified
    ///     <paramref name="defaultValue" />.
    /// </returns>
    protected TValue GetAppendedValue<TValue>(string key, TValue defaultValue = default)
    {
        if (appendArguments.TryGetValue(key, out var objValue) && objValue is TValue value)
        {
            return value;
        }

        return defaultValue;
    }

    /// <summary>
    ///     Gets the stored value with the specified
    ///     <paramref name="key" />.
    /// </summary>
    /// <param name="key">The key/id of the value.</param>
    /// <typeparam name="TValue">
    ///     The expected type the value should be in.
    /// </typeparam>
    /// <returns>
    ///     The stored value, or the default value for a collection.
    /// </returns>
    protected ICollection<TValue> GetPrependCollectionValue<TValue>(string key)
    {
        var collection = GetPrependValue<ICollection<TValue>>(key);

        if (collection is null)
        {
            collection = new List<TValue>();
            PrependValue(key, collection);
        }

        return collection;
    }

    /// <summary>
    ///     Gets the stored value with the specified
    ///     <paramref name="key" />.
    /// </summary>
    /// <param name="key">The key/id of the value.</param>
    /// <param name="defaultValue">
    ///     The value to return if no value have been stored.
    /// </param>
    /// <typeparam name="TValue">
    ///     The expected type the value should be in.
    /// </typeparam>
    /// <returns>
    ///     The stored value, or the specified
    ///     <paramref name="defaultValue" />.
    /// </returns>
    protected TValue GetPrependValue<TValue>(string key, TValue defaultValue = default)
    {
        if (prependArguments.TryGetValue(key, out var objValue) && objValue is TValue value)
        {
            return value;
        }

        return defaultValue;
    }

    /// <summary>
    ///     Stores the specified <paramref name="value" /> with the
    ///     specified <paramref name="key" /> as an argument that should
    ///     be prepended before the command name.
    /// </summary>
    /// <param name="key">The key/name to use for the argument.</param>
    /// <param name="value">
    ///     The value that should be part of the key.
    /// </param>
    /// <param name="allowEmptyValue">
    ///     if set to <c>true</c> allow the argument to be used without a
    ///     value.
    /// </param>
    /// <remarks>
    ///     Marking allow empty value stores empty and whitespace values,
    ///     but remove any passed null values.
    /// </remarks>
    protected void PrependValue(string key, object value, bool allowEmptyValue = false)
        => SetValue(prependArguments, key, value, allowEmptyValue);

    private static void SetValue(IDictionary<string, object> storage, string key, object value, bool allowEmptyValue)
    {
        if (value is null || (!allowEmptyValue && value is string sValue && string.IsNullOrWhiteSpace(sValue)))
        {
            if (storage.ContainsKey(key))
            {
                _ = storage.Remove(key);
            }
        }
        else
        {
            storage[key] = value;
        }
    }
}

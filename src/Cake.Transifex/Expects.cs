// <copyright file="Expects.cs" company="Cake Contrib">
// Copyright (c) 2017-2024 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>
///     Contains a collection of helpers to use when ensuring certain
///     conditions.
/// </summary>
/// <remarks>
///     New conditions should be added to this class when needed.
/// </remarks>
internal static class Expects
{
    /// <summary>
    ///     Asserts that the specified <paramref name="value" /> is not
    ///     <c>null</c>.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value to assert.</param>
    /// <param name="parameterName">Name of the parameter.</param>
    /// <exception cref="System.ArgumentNullException">
    ///     If the passed in <paramref name="value" /> is <c>null</c>.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void NotNull<TValue>([NotNull] TValue value, [CallerArgumentExpression(nameof(value))] string parameterName = null)
        => ArgumentNullException.ThrowIfNull(value, parameterName);

    /// <summary>
    ///     Asserts that the specified <paramref name="value" /> is not
    ///     <c>null</c> or white space.
    /// </summary>
    /// <param name="value">The value to assert.</param>
    /// <param name="parameterName">Name of the parameter.</param>
    /// <exception cref="System.ArgumentNullException">
    ///     If the passed in <paramref name="value" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    ///     If the passed in <paramref name="value" /> is empty or only
    ///     contain white space.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void NotNullOrWhitespace([NotNull] string value, [CallerArgumentExpression(nameof(value))] string parameterName = null)
    {
#if NET7_0_OR_GREATER
        ArgumentNullException.ThrowIfNullOrEmpty(value?.Trim(), parameterName);
#else
        NotNull(value, parameterName);

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(null, nameof(value));
        }
#endif
    }

    /// <summary>
    ///     Asserts that the specified <paramref name="value" /> is between
    ///     the specified <paramref name="minimum" /> and
    ///     <paramref name="maximum" /> values (Inclusive).
    /// </summary>
    /// <param name="minimum">The inclusive minimum value expected.</param>
    /// <param name="maximum">The inclusive maximum value expected.</param>
    /// <param name="value">The value to assert.</param>
    /// <param name="parameterName">Name of the parameter.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">
    ///     Value must be between <paramref name="minimum" /> and
    ///     <paramref name="maximum" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Range(int minimum, int maximum, int value, [CallerArgumentExpression(nameof(value))] string parameterName = null)
    {
        if (value < minimum || value > maximum)
        {
            throw new ArgumentOutOfRangeException(parameterName, $"Value must be between {minimum} and {maximum}.");
        }
    }
}

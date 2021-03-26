// <copyright file="GlobalSuppressions.cs" company="Cake Contrib">
// Copyright (c) 2017-2021 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S4018:Generic methods should provide type parameters", Justification = "We have this for convinience", Scope = "member", Target = "~M:Cake.Transifex.TransifexRunnerSettings.GetValue``1(System.String)~``0")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S4040:Strings should be normalized to uppercase", Justification = "Transifex expects it to be lowercase", Scope = "member", Target = "~M:Cake.Transifex.TransifexRunner.SetArguments(Cake.Core.IO.ProcessArgumentBuilder,Cake.Transifex.TransifexRunnerSettings)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Vulnerability", "S2068:Credentials should not be hard-coded", Justification = "Credential is not hard coded in library", Scope = "member", Target = "~F:Cake.Transifex.TransifexInitSettings.PasswordKey")]

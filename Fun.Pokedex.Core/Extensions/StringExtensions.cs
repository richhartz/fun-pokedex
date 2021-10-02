// <copyright file="StringExtensions.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Extensions
{
    /// <summary>
    /// Custom string extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces \n and \f with spaces.
        /// </summary>
        /// <param name="str">the string to clean up.</param>
        /// <returns>The cleaned string.</returns>
        public static string ReplaceLineBreaksWithSpaces(this string str)
        {
            return str?.Replace("\n", " ").Replace("\f", " ");
        }
    }
}

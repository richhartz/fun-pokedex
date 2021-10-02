// <copyright file="Guard.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Utils
{
    using System;

    /// <summary>
    /// A static guard helper class for checking arguments.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// throws ArgumentNullException is value is null.
        /// </summary>
        /// <param name="argumentName">The name of the argument to check.</param>
        /// <param name="value">The value of the argument.</param>
        public static void AgainstNull(string argumentName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}

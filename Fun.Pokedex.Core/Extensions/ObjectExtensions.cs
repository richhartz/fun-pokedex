// <copyright file="ObjectExtensions.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Extensions
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Object extensions, well one anyway.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns either an ok result or no content if the object is null.
        /// </summary>
        /// <param name="obj">The result object to check.</param>
        /// <returns>OkResult or NoContentResult.</returns>
        public static ActionResult ToActionResult(this object obj)
        {
            return obj != null ? new OkObjectResult(obj) : new NoContentResult();
        }
    }
}
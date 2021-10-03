// <copyright file="FunExceptionHandlingAppBuilderExtensions.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

using System;

namespace Fun.ExceptionHandling.Startup
{
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    /// IApplicationBuilder extensions to set up error handling.
    /// </summary>
    public static class FunExceptionHandlingAppBuilderExtensions
    {
        /// <summary>
        /// Sets up the error handling middleware.
        /// </summary>
        /// <param name="app">the <see cref="IApplicationBuilder"/>.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> which middleware added.</returns>
        public static IApplicationBuilder UseFunExceptionHandler(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<FunExceptionHandlingMiddleware>();
        }
    }
}

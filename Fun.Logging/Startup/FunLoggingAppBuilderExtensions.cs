// <copyright file="FunLoggingAppBuilderExtensions.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Logging.Startup
{
    using Microsoft.AspNetCore.Builder;
    using Serilog;
    using System;

    /// <summary>
    /// IApplicationBuilder extensions to set up error handling.
    /// </summary>
    public static class FunLoggingAppBuilderExtensions
    {
        /// <summary>
        /// Configures logging for the application.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> which middleware added.</returns>
        // ReSharper disable once UnusedMember.Global
        public static IApplicationBuilder UseFunLogging(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseSerilogRequestLogging();
        }
    }
}


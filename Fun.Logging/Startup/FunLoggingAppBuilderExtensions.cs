// <copyright file="FunLoggingAppBuilderExtensions.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

using Serilog;

namespace Fun.Logging.Startup
{
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    /// IApplicationBuilder extensions to set up error handling.
    /// </summary>
    public static class FunLoggingAppBuilderExtensions
    {
        /// <summary>
        /// Sets up the error handling middleware.
        /// </summary>
        /// <param name="app">the <see cref="IApplicationBuilder"/>.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> which middleware added.</returns>
        public static void UseFunErrorLogging(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorLoggingMiddleware>();
        }

        /// <summary>
        /// Configures logging for the application.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder"/>.</param>
        // ReSharper disable once UnusedMember.Global
        public static void UseFunLogging(this IApplicationBuilder builder)
        {
            builder.UseSerilogRequestLogging();
        }
    }
}

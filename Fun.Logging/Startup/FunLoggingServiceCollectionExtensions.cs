// <copyright file="FunLoggingServiceCollectionExtensions.cs" company="Fun">
// Copyright (c) Fun. All rights reserved.
// </copyright>

using System;

namespace Fun.Logging.Startup
{
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using Serilog.Events;
    using Serilog.Exceptions;
    using Serilog.Formatting.Compact;

    /// <summary>
    /// Extension methods to use Logging features.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public static class FunLoggingServiceCollectionExtensions
    {
        /// <summary>
        /// Configures logging for the application.
        /// </summary>
        /// <param name="services">The services collection of this application.</param>
        /// <param name="serviceName">Service name to log.</param>
        /// <param name="serviceVersion">Version to log.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddFunLogging(
            this IServiceCollection services,
            string serviceName, string serviceVersion)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProcessName()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .Enrich.WithExceptionDetails()
                .Enrich.WithProperty("ServiceName", serviceName)
                .Enrich.WithProperty("ServiceVersion", serviceVersion)
                .WriteTo.Console(new RenderedCompactJsonFormatter());

            Log.Logger = loggerConfiguration.CreateLogger();

            services.AddSingleton(Log.Logger);

            Log.Logger.Information("Fun Logging added");

            return services;
        }
    }
}
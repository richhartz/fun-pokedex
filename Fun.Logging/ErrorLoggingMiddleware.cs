// <copyright file="ErrorLoggingMiddleware.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Logging
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Serilog;

    /// <summary>
    /// Defines the ErrorLoggingMiddleware class.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger = Log.Logger;
        private readonly bool enableVerboseResponse = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorLoggingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The <see cref="RequestDelegate"/>.</param>
        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the next delegate.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/>.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        // ReSharper disable once AsyncConverter.AsyncMethodNamingHighlighting
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static string FormatVerbose(Exception ex)
        {
            return $"Exception: {ex} : Inner Exception: {ex.InnerException} : Stack Trace: {ex.StackTrace}";
        }

        private static string Format(Exception ex)
        {
            return $"Exception: {ex.Message}";
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Log the error.
            _logger.Error(exception, exception.Message);

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "text/plain";

                // Limit the returned status codes.
                if (context.Response.StatusCode != (int)HttpStatusCode.Unauthorized)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
            }

            if (enableVerboseResponse)
            {
                _logger.Verbose("Exception: {Exception}. Inner Exception: {InnerException}. Stack Trace: {StackTrace}.", exception, exception.InnerException, exception.StackTrace);

                await context.Response.WriteAsync(FormatVerbose(exception)).ConfigureAwait(false);
            }
            else
            {
                await context.Response.WriteAsync(Format(exception)).ConfigureAwait(false);
            }
        }
    }
}
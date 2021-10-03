// <copyright file="FunExceptionHandlingMiddleware.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.ExceptionHandling
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Serilog;

    /// <summary>
    /// Defines the FunExceptionHandlingMiddleware class.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class FunExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger = Log.Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunExceptionHandlingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The <see cref="RequestDelegate"/>.</param>
        public FunExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
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
                await next(context).ConfigureAwait(false);
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
            return $"Error: {ex.Message}";
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Handle custom exception types.
            if (exception is FunResourceNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                // Log the error.
                logger.Error(exception, exception.Message);

                // Limit the returned error status codes.
                if (context.Response.StatusCode != (int)HttpStatusCode.Unauthorized &&
                    context.Response.StatusCode != (int)HttpStatusCode.NotFound)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
            }

            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(Format(exception)).ConfigureAwait(false);
        }
    }
}
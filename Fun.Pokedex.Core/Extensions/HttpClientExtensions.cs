// <copyright file="HttpClientExtensions.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Extensions
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Class containing HttpClient Extension methods.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Simple extension for http client to deserialize to type TResult. any non success status code will return null and log the error response.
        /// </summary>
        /// <typeparam name="TResult">The expected return type.</typeparam>
        /// <param name="client">the http client.</param>
        /// <param name="requestUrl">The url to make the get request against.</param>
        /// <returns>The response content deserialize to type TResult. Or null if a non success status code is returned.</returns>
        public static async Task<TResult> GetAsync<TResult>(this HttpClient client, string requestUrl)
        {
            var response = await client.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                // TODO log.

                return default;
            }

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(responseString);
        }
    }
}

// <copyright file="TranslationApiClient.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.ApiClients
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.Extensions;
    using Fun.Pokedex.Core.Models.FunTranslation;

    /// <summary>
    /// Http client for making requests to the translation api.
    /// </summary>
    public class TranslationApiClient : ITranslationApiClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationApiClient"/> class.
        /// </summary>
        /// <param name="client">Provides a base first sending http request and receiving http responses.</param>
        public TranslationApiClient(HttpClient client)
        {
            httpClient = client;
        }

        /// <inheritdoc cref="ITranslationApiClient.TranslateAsync"/>
        public async Task<TranslationModel> TranslateAsync(string text, string translationTo)
        {
            return await httpClient.GetAsync<TranslationModel>($"translate/{translationTo}?text={text}");
        }
    }
}

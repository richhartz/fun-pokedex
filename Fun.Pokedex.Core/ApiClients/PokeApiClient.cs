// <copyright file="PokeApiClient.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.ApiClients
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.Extensions;
    using Fun.Pokedex.Core.Models.PokeApi;

    /// <inheritdoc cref="IPokeApiClient"/>
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokeApiClient"/> class.
        /// </summary>
        /// <param name="client">Provides a base first sending http request and receiving http responses.</param>
        public PokeApiClient(HttpClient client)
        {
            httpClient = client;
        }

        /// <inheritdoc cref="IPokeApiClient.GetSpeciesAsync"/>
        public async Task<PokemonSpeciesModel> GetSpeciesAsync(string name)
        {
            return await httpClient.GetAsync<PokemonSpeciesModel>($"pokemon-species/{name}");
        }
    }
}

// <copyright file="IPokeApiClient.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.ApiClients
{
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.Models.PokeApi;

    /// <summary>
    /// Api client definition for making requests to PokeApi.
    /// </summary>
    public interface IPokeApiClient
    {
        /// <summary>
        /// Calls the pokemon-species/{name} endpoint.
        /// </summary>
        /// <param name="name">The name of the pokemon species.</param>
        /// <returns>the <see cref="PokemonSpeciesModel"/>.</returns>
        Task<PokemonSpeciesModel> GetSpeciesAsync(string name);
    }
}
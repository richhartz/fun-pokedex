// <copyright file="IPokedexService.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Services
{
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.Models;

    /// <summary>
    /// Definition of the pokedex service.
    /// </summary>
    public interface IPokedexService
    {
        /// <summary>
        /// Returns basic information for a pokemon species.
        /// </summary>
        /// <param name="name">The name of the pokemon species.</param>
        /// <returns>A <see cref="PokemonResultModel"/>.</returns>
        public Task<PokemonResultModel> GetByNameAsync(string name);

        /// <summary>
        /// Returns basic information for a pokemon species with the description translated.
        /// </summary>
        /// <param name="name">The name of the pokemon species.</param>
        /// <returns>A <see cref="PokemonResultModel"/>.</returns>
        public Task<PokemonResultModel> GetTranslatedAsync(string name);
    }
}

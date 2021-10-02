// <copyright file="PokemonSpeciesModelExtensions.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Extensions
{
    using System.Linq;
    using Fun.Pokedex.Core.Constants;
    using Fun.Pokedex.Core.Models;
    using Fun.Pokedex.Core.Models.PokeApi;

    /// <summary>
    /// Extensions to the class <see cref="PokemonSpeciesModel"/>.
    /// </summary>
    public static class PokemonSpeciesModelExtensions
    {
        /// <summary>
        /// Maps a <see cref="PokemonSpeciesModel"/> to a <see cref="PokemonResultModel"/>.
        /// </summary>
        /// <param name="model">The <see cref="PokemonSpeciesModel"/>.</param>
        /// <returns>the pokemonModel or or null if model input is null.</returns>
        public static PokemonResultModel ToPokemonModel(this PokemonSpeciesModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new PokemonResultModel
            {
                Id = model.Id,
                Name = model.Name,
                IsLegendary = model.IsLegendary,
                Description = model.Description(),
                Language = Languages.Default,
                Habitat = model.Habitat?.Name,
            };
        }

        /// <summary>
        /// Maps a <see cref="PokemonSpeciesModel"/> to a <see cref="PokemonResultModel"/>.
        /// </summary>
        /// <param name="model">The <see cref="PokemonSpeciesModel"/>.</param>
        /// <returns>Cleaned description string from the first flavor text entry matching the default language.</returns>
        private static string Description(this PokemonSpeciesModel model)
        {
            return model.FlavorTextEntries?.FirstOrDefault(x => x.Language.Name == Languages.Default)?.Text;
        }
    }
}

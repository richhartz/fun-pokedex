// <copyright file="PokemonSpeciesModel.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Models.PokeApi
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A dto model for retrieving information from the pokeApi.
    /// </summary>
    public class PokemonSpeciesModel : NamedResourceModel
    {
        /// <summary>
        /// Gets the pokemon species id as defined by the poke api.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the pokemon habitat id as defined by the poke api.
        /// </summary>
        public NamedResourceModel Habitat { get; set; }

        /// <summary>
        /// Gets the list of flavor text entries returned by the poke api.
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public IEnumerable<FlavorTextModel> FlavorTextEntries { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether the pokemon is a legend.
        /// </summary>
        [JsonProperty("is_Legendary")]
        public bool IsLegendary { get; set; }
    }
}

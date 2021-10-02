// <copyright file="PokemonResultModel.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Models
{
    // ReSharper disable UnusedAutoPropertyAccessor.Global

    /// <summary>
    /// A model providing basic pokemon inforation.
    /// </summary>
    public class PokemonResultModel
    {
        /// <summary>
        /// Gets the pokemon species id as defined by the poke api.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets the pokemon species id as defined by the poke api.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Gets or sets the description as defined by the poke api, this may be translated.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the pokemon habitat id as defined by the poke api.
        /// </summary>
        public string Habitat { get; init; }

        /// <summary>
        /// Gets a value indicating whether the pokemon is ** legend.
        /// </summary>
        public bool IsLegendary { get; init; }

        /// <summary>
        /// Gets or sets a value indicating the language used in the description.
        /// </summary>
        public string Language { get; set; }
    }
}

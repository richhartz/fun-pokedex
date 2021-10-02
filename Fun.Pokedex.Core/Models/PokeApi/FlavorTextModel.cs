// <copyright file="FlavorTextModel.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Models.PokeApi
{
    using Newtonsoft.Json;

    /// <summary>
    /// The flavor text for a pokemon.
    /// </summary>
    public class FlavorTextModel
    {
        /// <summary>
        /// Gets the localized name for an API resource in a specific language.
        /// </summary>
        [JsonProperty("flavor_text")]
        public string Text { get; init; }

        /// <summary>
        /// Gets the language this text resource is in.
        /// </summary>
        public NamedResourceModel Language { get; init; }
    }
}

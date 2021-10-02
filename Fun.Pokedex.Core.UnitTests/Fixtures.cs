// <copyright file="Fixtures.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.UnitTests
{
    using System.Collections.Generic;
    using Fun.Pokedex.Core.Constants;
    using Fun.Pokedex.Core.Models;
    using Fun.Pokedex.Core.Models.PokeApi;

    public static class Fixtures
    {
        public static PokemonSpeciesModel PokemonSpeciesModel => new ()
        {
            Id = 1,
            Name = "mewtwo",
            IsLegendary = true,
            Habitat = new NamedResourceModel { Name = "rare" },
            FlavorTextEntries = new List<FlavorTextModel>
            {
                new ()
                {
                    Language = new NamedResourceModel { Name = Languages.Default },
                    Text =
                        "It was created by a scientist\n after years of horrific\fgene splicing and DNA engineering experiments.",
                },
            },
        };
    }
}

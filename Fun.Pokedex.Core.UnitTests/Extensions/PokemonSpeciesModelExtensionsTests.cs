// <copyright file="PokemonSpeciesModelExtensionsTests.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.UnitTests.Extensions
{
    using System.Linq;
    using Fun.Pokedex.Core.Constants;
    using Fun.Pokedex.Core.Extensions;
    using NUnit.Framework;

    public class PokemonSpeciesModelExtensionsTests
    {
        [Test]
        public void ToPokemonModel_Should_Map_Id_Field_Correctly()
        {
            // Act
            var actual = Fixtures.PokemonSpeciesModel.ToPokemonModel();

            Assert.AreEqual(Fixtures.PokemonSpeciesModel.Id, actual.Id);
        }

        [Test]
        public void ToPokemonModel_Should_Map_Name_Field_Correctly()
        {
            // Act
            var actual = Fixtures.PokemonSpeciesModel.ToPokemonModel();

            Assert.AreEqual(Fixtures.PokemonSpeciesModel.Name, actual.Name);
        }

        [Test]
        public void ToPokemonModel_Should_Map_IsLegendary_Field_Correctly()
        {
            // Act
            var actual = Fixtures.PokemonSpeciesModel.ToPokemonModel();

            Assert.AreEqual(Fixtures.PokemonSpeciesModel.IsLegendary, actual.IsLegendary);
        }

        [Test]
        public void ToPokemonModel_Should_Map_Habitat_Field_Correctly()
        {
            // Act
            var actual = Fixtures.PokemonSpeciesModel.ToPokemonModel();

            Assert.AreEqual(Fixtures.PokemonSpeciesModel.Habitat.Name, actual.Habitat);
        }

        [Test]
        public void ToPokemonModel_Should_Map_Description_Field_Correctly()
        {
            // Act
            var actual = Fixtures.PokemonSpeciesModel.ToPokemonModel();

            var expected = Fixtures.PokemonSpeciesModel.FlavorTextEntries.FirstOrDefault(x => x.Language.Name == Languages.Default)?.Text;

            // Assert
            Assert.AreEqual(expected, actual.Description);
        }
    }
}

// <copyright file="GetNameAsync.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.UnitTests.PokedexServiceTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.Constants;
    using Fun.Pokedex.Core.Extensions;
    using Fun.Pokedex.Core.Models;
    using Fun.Pokedex.Core.Services;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the method <see cref="PokedexService.GetByNameAsync"/>.
    /// </summary>
    public class GetNameAsync : PokadexServiceTestsBase
    {
        [TestCase("bulbasaur")]
        [TestCase("ivysaur")]
        public void GetByNameAsync_ShouldCall_PokeApiClient_GetSpecies_Once(string name)
        {
            // Act
            ServiceUnderTest.GetByNameAsync(name);

            // Assert
            MockPokeApiClient.Verify(x => x.GetSpeciesAsync(name), Times.Once);
        }

        [Test]
        public async Task GetByNameAsync_Should_Return_Correct_InstanceType()
        {
            // Act
            var actual = await ServiceUnderTest.GetByNameAsync(Fixtures.PokemonSpeciesModel.Name);

            // Act
            Assert.IsInstanceOf<PokemonResultModel>(actual);
        }

        [Test]
        public async Task GetByNameAsync_Should_Return_Correct_Id_Field()
        {
            // Act
            var actual = await ServiceUnderTest.GetByNameAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            Assert.AreEqual(Fixtures.PokemonSpeciesModel.Id, actual.Id);
        }

        [Test]
        public async Task GetByNameAsync_Should_Return_Correct_Name_Field()
        {
            // Act
            var actual = await ServiceUnderTest.GetByNameAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            Assert.AreEqual(Fixtures.PokemonSpeciesModel.Name, actual.Name);
        }

        [Test]
        public async Task GetByNameAsync_Should_Return_Correct_IsLegendary_Field()
        {
            // Act
            var actual = await ServiceUnderTest.GetByNameAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            Assert.AreEqual(Fixtures.PokemonSpeciesModel.IsLegendary, actual.IsLegendary);
        }

        [Test]
        public async Task GetByNameAsync_Should_Return_Correct_Habitat_Field()
        {
            // Act
            var actual = await ServiceUnderTest.GetByNameAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            Assert.AreEqual(Fixtures.PokemonSpeciesModel.Habitat.Name, actual.Habitat);
        }

        [Test]
        public async Task GetByNameAsync_Should_Return_Correct_Description_Field()
        {
            // Act
            var actual = await ServiceUnderTest.GetByNameAsync(Fixtures.PokemonSpeciesModel.Name);

            var expected = Fixtures.PokemonSpeciesModel.FlavorTextEntries
                .FirstOrDefault(x => x.Language.Name == Languages.Default)?.Text.ReplaceLineBreaksWithSpaces();

            // Assert
            Assert.AreEqual(expected, actual.Description);
        }

        [Test]
        public async Task GetByNameAsync_Should_Return_Correct_Language_Field()
        {
            // Act
            var actual = await ServiceUnderTest.GetByNameAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            Assert.AreEqual(Languages.Default, actual.Language);
        }
    }
}
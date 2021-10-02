// <copyright file="GetTranslatedAsync.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.UnitTests.PokedexServiceTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.Constants;
    using Fun.Pokedex.Core.Extensions;
    using Fun.Pokedex.Core.Models;
    using Fun.Pokedex.Core.Models.PokeApi;
    using Fun.Pokedex.Core.Services;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the method <see cref="PokedexService.GetByNameAsync"/>.
    /// </summary>
    public class GetTranslatedAsync : PokadexServiceTestsBase
    {
        [TestCase("bulbasaur")]
        [TestCase("ivysaur")]
        public void ShouldCall_PokeApiClient_GetSpecies_Once(string name)
        {
            // Act
            ServiceUnderTest.GetTranslatedAsync(name);

            // Assert
            MockPokeApiClient.Verify(x => x.GetSpeciesAsync(name), Times.Once);
        }

        [Test]
        public async Task Given_PokeApi_Returns_Null_Should_Return_Null()
        {
            // Arrange
            MockPokeApiClient.Setup(x => x.GetSpeciesAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(default(PokemonSpeciesModel)));

            // Act
            var actual = await ServiceUnderTest.GetTranslatedAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void Given_Parameter_Is_Null_Should_Throw_ArgumentNullException()
        {
            // Act / Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await ServiceUnderTest.GetTranslatedAsync(null));
        }

        [Test]
        public async Task Should_Return_Correct_InstanceType()
        {
            // Act
            var actual = await ServiceUnderTest.GetTranslatedAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            Assert.IsInstanceOf<PokemonResultModel>(actual);
        }

        [Test]
        public async Task Should_Return_Call_Translation_Api_Once()
        {
            // Act
            await ServiceUnderTest.GetTranslatedAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            MockTranslationApiClient.Verify(x => x.TranslateAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [TestCase(true, "cave")]
        [TestCase(true, "NOT cave")]
        [TestCase(false, "cave")]
        public async Task Given_Pokemon_Is_Legendary_Or_Lives_In_A_Cave_Should_Request_Yoda_Translation(bool isLegendary, string habitat)
        {
            // Arrange
            ArrangeMocks(isLegendary, habitat);

            // Act
            await ServiceUnderTest.GetTranslatedAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            MockTranslationApiClient.Verify(x => x.TranslateAsync(It.IsAny<string>(), Languages.Yoda), Times.Once());
        }

        [Test]
        public async Task Given_Pokemon_IsNotLegendary_And_DoesNot_Lives_In_A_Cave_Should_Request_Shakespeare_Translation()
        {
            // Arrange
            ArrangeMocks(false, "NOT cave");

            // Act
            await ServiceUnderTest.GetTranslatedAsync(Fixtures.PokemonSpeciesModel.Name);

            // Assert
            MockTranslationApiClient.Verify(x => x.TranslateAsync(It.IsAny<string>(), Languages.Shakespeare), Times.Once());
        }

        [Test]
        public async Task Given_Translation_IsNotAvailable_Should_Return_DefaultDescription()
        {
            // Arrange
            MockTranslationApiClient.Setup(x => x.TranslateAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(default(TranslationModel)));

            // Act
            var actual = await ServiceUnderTest.GetTranslatedAsync(Fixtures.PokemonSpeciesModel.Name);

            var expected = Fixtures.PokemonSpeciesModel.FlavorTextEntries
                .FirstOrDefault(x => x.Language.Name == Languages.Default)?.Text.ReplaceLineBreaksWithSpaces();

            // Assert
            Assert.AreEqual(expected, actual.Description);
        }

        private void ArrangeMocks(bool isLegendary, string habitat)
        {
            var testModel = Fixtures.PokemonSpeciesModel;

            testModel.IsLegendary = isLegendary;
            testModel.Habitat.Name = habitat;

            MockPokeApiClient.Setup(x => x.GetSpeciesAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(testModel));
        }
    }
}
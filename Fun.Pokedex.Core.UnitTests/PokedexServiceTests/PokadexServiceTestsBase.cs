// <copyright file="PokadexServiceTestsBase.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.UnitTests.PokedexServiceTests
{
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.ApiClients;
    using Fun.Pokedex.Core.Services;
    using Moq;
    using NUnit.Framework;

    public class PokadexServiceTestsBase
    {
        protected Mock<IPokeApiClient> MockPokeApiClient { get; set; }

        protected Mock<ITranslationApiClient> MockTranslationApiClient { get; set; }

        protected IPokedexService ServiceUnderTest =>
            new PokedexService(MockPokeApiClient.Object, MockTranslationApiClient.Object);

        [SetUp]
        protected void Setup()
        {
            MockPokeApiClient = new Mock<IPokeApiClient>();
            MockTranslationApiClient = new Mock<ITranslationApiClient>();

            MockPokeApiClient.Setup(x => x.GetSpeciesAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(Fixtures.PokemonSpeciesModel));
        }
    }
}
// <copyright file="PokedexService.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Services
{
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.ApiClients;
    using Fun.Pokedex.Core.Constants;
    using Fun.Pokedex.Core.Extensions;
    using Fun.Pokedex.Core.Models;
    using Fun.Pokedex.Core.Utils;

    /// <summary>
    /// service for retrieving pokemon data from the apis.
    /// </summary>
    public class PokedexService : IPokedexService
    {
        private readonly IPokeApiClient pokeApiClient;
        private readonly ITranslationApiClient translationApiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokedexService"/> class.
        /// </summary>
        /// <param name="pokeApi">HttpClient wrapper for PokeApi, <see cref="PokeApiClient"/>.</param>
        /// <param name="translationApi">HttpClient wrapper for translations, <see cref="TranslationApiClient"/>.</param>
        public PokedexService(IPokeApiClient pokeApi, ITranslationApiClient translationApi)
        {
            pokeApiClient = pokeApi;
            translationApiClient = translationApi;
        }

        /// <inheritdoc cref="IPokedexService.GetByNameAsync"/>
        public async Task<PokemonResultModel> GetByNameAsync(string name)
        {
            Guard.AgainstNull(nameof(name), name);

            var speciesModel = await pokeApiClient.GetSpeciesAsync(name);

            return speciesModel.ToPokemonModel();
        }

        /// <inheritdoc cref="IPokedexService.GetTranslatedAsync"/>
        public async Task<PokemonResultModel> GetTranslatedAsync(string name)
        {
            Guard.AgainstNull(nameof(name), name);

            var pokemon = await GetByNameAsync(name);

            if (pokemon == null)
            {
                return null;
            }

            var translateTo = pokemon.IsLegendary || (pokemon.Habitat == Habitats.Cave) ? Languages.Yoda : Languages.Shakespeare;

            var translation = await translationApiClient.TranslateAsync(pokemon.Description, translateTo);

            if (translation?.Contents != null)
            {
                pokemon.Description = translation.Contents.Translated;
                pokemon.Language = translateTo;
            }

            return pokemon;
        }
    }
}

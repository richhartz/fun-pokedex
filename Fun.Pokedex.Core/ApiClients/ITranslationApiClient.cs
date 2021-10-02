// <copyright file="ITranslationApiClient.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.ApiClients
{
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.Models;
    using Fun.Pokedex.Core.Models.FunTranslation;

    /// <summary>
    /// definition of the api client for making requests to the translation api.
    /// </summary>
    public interface ITranslationApiClient
    {
        /// <summary>
        /// Calls the translate/{translationType}?text={text} endpoint.
        /// </summary>
        /// <param name="text">The test to translate.</param>
        /// <param name="translationTo">The language to translate to, e.g 'yoda', 'shakespeare'.</param>
        /// <returns>The <see cref="TranslationModel"/>.</returns>
        Task<TranslationModel> TranslateAsync(string text, string translationTo);
    }
}
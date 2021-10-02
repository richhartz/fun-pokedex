// <copyright file="TranslationContentsModel.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Models
{
    /// <summary>
    /// Dto for reading in translation responses.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TranslationContentsModel
    {
        /// <summary>
        /// Gets the translated text.
        /// </summary>
        public string Translated { get; init; }
    }
}
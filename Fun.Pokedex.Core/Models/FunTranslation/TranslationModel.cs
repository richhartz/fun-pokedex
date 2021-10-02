// <copyright file="TranslationModel.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.Models
{
    /// <summary>
    /// Dto for used to read translation responses.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TranslationModel
    {
        /// <summary>
        /// gets an object which is just a wrapper for the translated text.
        /// </summary>
        public TranslationContentsModel Contents { get; init; }
    }
}

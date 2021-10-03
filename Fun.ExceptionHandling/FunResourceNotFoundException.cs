// <copyright file="FunResourceNotFoundException.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.ExceptionHandling
{
    using System;

    /// <summary>
    /// The FunResourceNotFoundException type.
    /// </summary>
    [Serializable]
    public class FunResourceNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunResourceNotFoundException"/> class.
        /// </summary>
        public FunResourceNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">the message.</param>
        public FunResourceNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner exception.</param>
        public FunResourceNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The <see cref="System.Runtime.Serialization.SerializationInfo"/>.</param>
        /// <param name="streamingContext">The <see cref="System.Runtime.Serialization.StreamingContext"/>.</param>
        protected FunResourceNotFoundException(
            System.Runtime.Serialization.SerializationInfo serializationInfo,
            System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
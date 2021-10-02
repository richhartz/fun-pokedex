// <copyright file="StringExtensionsTests.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.UnitTests.Extensions
{
    using Fun.Pokedex.Core.Extensions;
    using NUnit.Framework;

    public class StringExtensionsTests
    {
        [TestCase("foo", "foo")]
        [TestCase("foo\nbar", "foo bar")]
        [TestCase("foo\nbar\nbaz", "foo bar baz")]
        public void ReplaceLineBreaksWithSpaces_Should_Replace_Escaped_Characters(string input, string expected)
        {
            var actual = input.ReplaceLineBreaksWithSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}

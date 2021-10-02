// <copyright file="GuardTests.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.UnitTests.Utils
{
    using System;
    using Fun.Pokedex.Core.Utils;
    using NUnit.Framework;

    public class GuardTests
    {
        [Test]
        public void AgainstNullGiven_ShouldThrow_WhenNull()
        {
           Assert.Throws<ArgumentNullException>(() => Guard.AgainstNull("name", null));
        }

        [Test]
        public void AgainstNullGiven_ShouldNotThrow_WhenNotNull()
        {
            Assert.DoesNotThrow(() => Guard.AgainstNull("name", new object()));
        }
    }
}

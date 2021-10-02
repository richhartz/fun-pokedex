// <copyright file="ObjectExtensionsTests.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Core.UnitTests.Extensions
{
    using Fun.Pokedex.Core.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using NUnit.Framework;

    public class ObjectExtensionsTests
    {
        [Test]
        public void ToActionResult_ShouldReturnOkResult_WhenDataNotNull()
        {
            var actual = new object().ToActionResult();

            Assert.IsInstanceOf<OkObjectResult>(actual);
        }

        [Test]
        public void ToActionResult_ShouldReturn_NoContent_Result_WhenDataNull()
        {
            var actual = default(object).ToActionResult();

            Assert.IsInstanceOf<NoContentResult>(actual);
        }
    }
}

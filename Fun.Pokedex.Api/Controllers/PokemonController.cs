// <copyright file="PokemonController.cs" company="Pokedex :)">
// Copyright (c) Pokedex :). All rights reserved.
// </copyright>

namespace Fun.Pokedex.Api.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Fun.Pokedex.Core.Extensions;
    using Fun.Pokedex.Core.Models;
    using Fun.Pokedex.Core.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller containing pokemon actions.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokedexService pokedexService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokemonController"/> class.
        /// </summary>
        /// <param name="pokedexService">Instance of <see cref="IPokedexService"/>.</param>
        public PokemonController(IPokedexService pokedexService)
        {
            this.pokedexService = pokedexService;
        }

        /// <summary>
        /// Returns basic information for a pokemon species.
        /// </summary>
        /// <param name="name">The name of the pokemon species.</param>
        /// <returns>A <see cref="PokemonResultModel"/>.</returns>
        [HttpGet("/{name}")]
        public async Task<ActionResult> GetAsync([FromRoute] [Required] string name)
        {
            return (await pokedexService.GetByNameAsync(name)).ToActionResult();
        }

        /// <summary>
        /// Returns basic information for a pokemon species with the description translated.
        /// </summary>
        /// <param name="name">The name of the pokemon species.</param>
        /// <returns>A <see cref="PokemonResultModel"/>.</returns>
        [HttpGet("/translated/{name}")]
        public async Task<ActionResult> GetTranslatedAsync([FromRoute] [Required] string name)
        {
            return (await pokedexService.GetTranslatedAsync(name)).ToActionResult();
        }
    }
}

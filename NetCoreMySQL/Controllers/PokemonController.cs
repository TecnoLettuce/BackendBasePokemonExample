using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiMySQL.Data.Repositories;
using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPokemon()
        {
            return Ok(await _pokemonRepository.GetAllPokemon());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemonDetails(int id)
        {
            return Ok(await _pokemonRepository.GetPokemonDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePokemon ([FromBody] Pokemon pokemon)
        {

            // Validaciones 
            if (pokemon == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _pokemonRepository.InsertPokemon(pokemon);

            return Created("Created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePokemon([FromBody] Pokemon pokemon)
        {

            // Validaciones 
            if (pokemon == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _pokemonRepository.UpdatePokemon(pokemon);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            await _pokemonRepository.DeletePokemon(new Pokemon() { Id = id });

            return NoContent();
        }


    }
}

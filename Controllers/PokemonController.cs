using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrueLayerBackendEngineerChallenge.Services;

namespace TrueLayerBackendEngineerChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {

        private readonly HttpClient client = new HttpClient();
        private PokeApiService pokeApiService;
        public PokemonController()
        {
            this.pokeApiService = new PokeApiService();
        }

        [HttpGet]
        [Route("{pokemonName}")]
        public async Task<bool> Get(string pokemonName)
        {
            var isValidPokemon = await this.pokeApiService.IsValidPokemon(this.client, pokemonName);
            
            return isValidPokemon;
        }
    }
}

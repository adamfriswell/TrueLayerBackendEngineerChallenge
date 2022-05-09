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
            this.pokeApiService = new PokeApiService(this.client);
        }

        [HttpGet]
        [Route("{pokemonName}")]
        public async Task<string> Get(string pokemonName)
        {
            var description = await this.pokeApiService.GetPokemonDescription(this.client, pokemonName);
            return description;
        }
    }
}

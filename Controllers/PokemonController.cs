using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrueLayerBackendEngineerChallenge.Services;

namespace TrueLayerBackendEngineerChallenge.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase{
        private PokeApiService pokeApiService;
        private FunTranslationsApiService funTranslationsApiService;

        public PokemonController(){
            this.pokeApiService = new PokeApiService();
            this.funTranslationsApiService = new FunTranslationsApiService();
        }

        [HttpGet]
        [Route("{pokemonName}")]
        public async Task<string> Get(string pokemonName){
            var description = await this.pokeApiService.GetPokemonDescription(pokemonName);
            var shakespeareanDescription = await this.funTranslationsApiService.GetShakespeareanDescription(description);

            var resultObject = new {
                name = pokemonName,
                description = shakespeareanDescription
            };
            var result = JsonConvert.SerializeObject(resultObject);
            return result;
        }
    }
}

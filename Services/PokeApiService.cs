using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TrueLayerBackendEngineerChallenge.Services {

    public class PokeApiService {
        private string PokeApiEndpoint = "https://pokeapi.co/api/v2/";

        public async Task<bool> IsValidPokemon(HttpClient client, string pokemonName){
            client.BaseAddress = new Uri(this.PokeApiEndpoint);
            HttpResponseMessage response = await client.GetAsync($"pokemon/{pokemonName}");
            return response.IsSuccessStatusCode;
        }
    }
}
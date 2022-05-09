using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TrueLayerBackendEngineerChallenge.Models;

namespace TrueLayerBackendEngineerChallenge.Services {

    public class PokeApiService {
        private HttpClient client = new HttpClient();
        
        public PokeApiService()
        {
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public async Task<string> GetPokemonDescription(string pokemonName){
            //Call the 'pokemon-species/{pokemonName}' endpoint and read the content of the response as a string
            var response = await this.client.GetAsync($"pokemon-species/{pokemonName}");
            if(!response.IsSuccessStatusCode){
                throw new Exception("This Pokemom does not exist.");
            }
            string responseBody = await response.Content.ReadAsStringAsync();

            //Parse the response body to a JObejct, find the flavor_text_entries node and turn into its model
            var responseJObject = JObject.Parse(responseBody);
            var flavourTextEntriesJToken = responseJObject["flavor_text_entries"];
            var flavourTextEntries = flavourTextEntriesJToken.ToObject<flavor_text_entries[]>();

            //Find the flaour_text of the "ruby" version entry (if exists as this was used in example, if not take first), remove new line characters
            var flavour = flavourTextEntries.Where(f => f.version.name == "ruby").SingleOrDefault();
            if(flavour == null){
                flavour = flavourTextEntries.Where(f => f.language.name == "en").FirstOrDefault();
            }
            var rawDescription = flavour.flavor_text;
            var description = Regex.Replace(rawDescription, @"\t|\n|\r|\f", " ");
            return description;
        }
    }
}
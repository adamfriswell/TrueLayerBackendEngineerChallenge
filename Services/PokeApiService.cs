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
        
        public PokeApiService(){
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public async Task<string> GetPokemonDescription(string pokemonName){
            var responseBody = await GetResponse(pokemonName);
            var flavourTextEntries = ParseResponseToModel(responseBody);
            var description = GetDescription(flavourTextEntries);
            return description;
        }

        public async Task<string> GetResponse(string pokemonName){
            //Call the 'pokemon-species/{pokemonName}' endpoint and read the content of the response as a string
            var response = await this.client.GetAsync($"pokemon-species/{pokemonName}");
            if (!response.IsSuccessStatusCode){
                throw new Exception("This Pokemon does not exist.");
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public static flavor_text_entries[] ParseResponseToModel(string responseBody){
            //Parse the response body to a JObject, find the flavor_text_entries node and turn into its model
            var responseJObject = JObject.Parse(responseBody);
            var flavourTextEntriesJToken = responseJObject["flavor_text_entries"];
            if(flavourTextEntriesJToken == null){
                throw new Exception("Cannot find 'flavour_text_entries' node.");
            }
            var flavourTextEntries = flavourTextEntriesJToken.ToObject<flavor_text_entries[]>();
            return flavourTextEntries;
        }

        public static string GetDescription(flavor_text_entries[] flavourTextEntries){
            //Find the flavour_text of the "ruby" version entry (if exists as this was used in example, if not take first English version), remove new line characters
            if(flavourTextEntries == null){
                throw new Exception("No flavour text entries supplied.");
            }
            var flavour = flavourTextEntries.Where(f => f.version.name == "ruby").SingleOrDefault();
            if(flavour == null){
                flavour = flavourTextEntries.Where(f => f.language.name == "en").FirstOrDefault();
                if(flavour == null){
                    throw new Exception("There are no English descriptions for this Pokemon.");
                }
            }
            var rawDescription = flavour.flavor_text;
            var description = Regex.Replace(rawDescription, @"\t|\n|\r|\f", " ");
            return description;
        }
    }
}
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TrueLayerBackendEngineerChallenge.Services {

    public class FunTranslationsApiService {
        private HttpClient client = new HttpClient();
        public FunTranslationsApiService(){
            client.BaseAddress = new Uri("https://api.funtranslations.com/translate/");
        }

        public async Task<string> GetShakespeareanDescription(string description){
            var parsedDescription = Regex.Replace(description, " ", "%20");
            string responseBody = await GetResponse(parsedDescription);
            var translation = GetTranslation(responseBody);
            return translation;
        }

        public async Task<string> GetResponse(string parsedDescription){
            var response = await this.client.GetAsync($"shakespeare.json?text={parsedDescription}");
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    throw new Exception("Too many requests, FunTranslationsAPI is rate limited to 5 per hour.");
                }
                throw new Exception("Could not convert to Shakesperean text.");
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public static string GetTranslation(string responseBody){
            var responseJObject = JObject.Parse(responseBody);
            var content = responseJObject["contents"];
            if(content == null){
                throw new Exception("Cannot find 'content' node.");
            }
            var translated = content["translated"];
            if(translated == null){
                throw new Exception("Cannot find 'translated' node.");
            }
            var translation = translated.ToString();
            return translation;
        }
    }
}
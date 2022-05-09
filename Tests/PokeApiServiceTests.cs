using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TrueLayerBackendEngineerChallenge.Services;
using Xunit;

namespace TrueLayerBackendEngineerChallenge.Tests {
    public class PokeApiServiceTests {
        [Fact]
        public async void PokeApiService_GetResponse_Success() {
            var pokeApiService = new PokeApiService();

            var result = await pokeApiService.GetResponse("charizard");

            Assert.NotNull(result);
        }

        [Fact]
        public void PokeApiService_GetResponse_DoesNotExist() {
            var pokeApiService = new PokeApiService();

            Func<Task> act = async () => await pokeApiService.GetResponse("adamon");

            Exception exception = Assert.ThrowsAsync<Exception>(act).Result;
            Assert.Equal("This Pokemon does not exist.", exception.Message);
        }

        [Fact]
        public void PokeApiService_ParseResponseToModel_Success() {
            var entries = TestData.GetFlavorTextEntriesObject();
            var entriesArray = entries.ToArray();

            var mockResponse = TestData.PokemonSpeciesCharizardResult;
            var result = PokeApiService.ParseResponseToModel(mockResponse);

            var expectedJson = JsonConvert.SerializeObject(entriesArray);
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.Equal(expectedJson,resultJson);
        }

        [Fact]
        public void PokeApiService_ParseResponseToModel_Failure() {
            var mockResponse = TestData.UnexpectedJson;

            Action act = () => PokeApiService.ParseResponseToModel(mockResponse);
            Exception exception = Assert.Throws<Exception>(act);

            Assert.Equal("Cannot find flavour_text_entries node.", exception.Message);
        }

        [Fact]
        public void PokeApiService_GetDescription_RubyVersion() {
            var entries = TestData.GetFlavorTextEntriesObject();
            var entriesArray = entries.ToArray();

            var result = PokeApiService.GetDescription(entriesArray);

            Assert.Equal(TestData.RubyVersionFlavourText,result);
        }

        [Fact]
        public void PokeApiService_GetDescription_NoRubyVersion() {
            var entries = TestData.GetFlavorTextEntriesObjectWithoutRubyVersion();
            var entriesArray = entries.ToArray();

            var result = PokeApiService.GetDescription(entriesArray);

            Assert.Equal(TestData.CrystalVersionFlavourText, result);
        }

        [Fact]
        public void PokeApiService_GetDescription_NoEntries() {
            Action act = () => PokeApiService.GetDescription(null);
            Exception exception = Assert.Throws<Exception>(act);

            Assert.Equal("No flavour text entries supplied.", exception.Message);
        }

        [Fact]
        public void PokeApiService_GetDescription_NoEnglishDescriptions() {
            var entries = TestData.GetFlavorTextEntriesObjectWithBlackVersionOnly();
            var entriesArray = entries.ToArray(); 

            Action act = () => PokeApiService.GetDescription(entriesArray);
            Exception exception = Assert.Throws<Exception>(act);

            Assert.Equal("There are no English descriptions for this Pokemon.", exception.Message);
        }
    }
}
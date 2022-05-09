using TrueLayerBackendEngineerChallenge.Controllers;
using Xunit;

namespace TrueLayerBackendEngineerChallenge.Tests{
    public class PokemonControllerTests{
       [Fact]
        public async void PokemonController_Get_Success(){
            var pokemonController = new PokemonController();
            
            var result = await pokemonController.Get("charizard");

            var expectedTranslation = TestData.RubyVersionFlavourTextTranslated;
            Assert.Equal(expectedTranslation, result);
        }
    }
}
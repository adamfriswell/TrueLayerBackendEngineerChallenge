using System;
using TrueLayerBackendEngineerChallenge.Controllers;
using Xunit;

namespace TrueLayerBackendEngineerChallenge.Tests
{
    public class PokemonControllerTests
    {
       [Fact]
        public async void PokemonController_Get_Success(){
            //Arrange
            var pokemonController = new PokemonController();
            
            //Act
            var result = await pokemonController.Get("charizard");

            //Assert
            var expectedTranslation = "Charizard flies 'round the sky in search of powerful opponents. 't breathes fire of such most wondrous heat yond 't melts aught. However, 't nev'r turns its fiery breath on any opponent weaker than itself.";
            Assert.Equal(expectedTranslation, result);
        }
    }
}
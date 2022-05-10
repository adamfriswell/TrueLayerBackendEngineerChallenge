# TrueLayer Backend Engineer Challenge:

## The challenge:
Write a RESTful Pokemon API with a GET method that returns a Shakespearean description for a given Pokemon name.
See [TrueLayer - Backend Engineer Payments Challenge.pdf](https://github.com/adamfriswell/TrueLayerBackendEngineerChallenge/blob/master/TrueLayer%20-%20Backend%20Engineer%20Payments%20Challenge.pdf) for full details.
API's used:
* [Pokemon API](https://pokeapi.co/)
* [FunTranslations API - Shakespear Translator](https://funtranslations.com/api/shakespeare)

## To run:
* Install the [dotnet sdk](https://dotnet.microsoft.com/en-us/download)
* Serve the site by running `dotnet run` in the terminal
* Can call API 2 ways
    * Navigate to /swagger endpoint to see the Swagger generated UI, then can use the "Try it out" button to add a pokemonName
    * Append "/pokemon/{pokemonName}" to the localhost URL (https://localhost:5001/)
* To run the tests run `dotnet test` in the terminal
    * Please note if playing with API and running unit tests multiple times then the `PokemonController_Get_Success` and `FunTranslationsApiService_GetResponse_Success` tests may fail with a error of "Too Many Requests", as the FunTranslations API is rate limited to 5 calls per hour.

## Implementation notes:
Here I am going to detail how I went about implementing my solution to this challenge:
* First I made a new dotnet webapi project, by running the `dotnet new webapi` command in the terminal
* I added XUnit and related nuget package needed to write some unit tests, and made an empty `PokemonControllerTests.cs` class just to make sure the tests would run properly.
* My first consideration for what this GET method should be doing is calling the prescribed PokeAPI to check that the given Pokemon name is actually a valid Pokemon. 
    * So I just called the `pokemon/{pokemonName}` endpoint of the PokeAPI and ensured this gave a valid response.
* Next I wanted to get a description of the Pokemon in question to be able to translate into Shakespearean text.
    * This proved more difficult than expeced, as I would have assumed there was a description field on the `pokemon/{pokemonName}` call
    * [It turns out](https://github.com/PokeAPI/pokeapi/issues/107) there are different "flavours" of Pokemon from different versions of the game, with different descriptions
    * The PokeAPI stores these different descriptions (it calls them `flavor_text`) under the `flavor_text_entries` of the `pokemon-species/{pokemonName}` call
    * The description used in the example for the task came from the ruby version, thus I'm using this version of the description if it exists, and if not the first version returned which is in English (as not all `flavor_text`'s that are returned are in English)
* I realised my above point about calling `pokemon/{pokemonName}` to make sure the pokemon name was valid was unnecessary, as the `pokemon-species` call would return a "Not Found" body if it doesn't exist, so I removed this.
* I then called the Fun Translations API `translate/shakespear` endpoint to convert this description into its shakesperean version
* To finish off I added some unit tests for the `PokemonController`, `PokeApiService` and `FunTranslationsApiService`

## Areas for improvement:
* More error handling, and handling more gracefully
* Unit testing
    * Wider range of tests to test more edge cases
    * Read Json from test date files rather than storing as const string in `TestData.cs`, then can assert more than just not null in `PokeApiService_GetResponse_Success` and `FunTranslationsApiService_GetResponse_Success`
* Look into including Dockerfile as mentioned in task spec
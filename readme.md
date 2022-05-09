# TrueLayer Backend Engineer Challenge:

## The challenge:
Write a RESTful Pokemon API with a GET method that returns a Shakespearean description for a given Pokemon name.
See [TrueLayer - Backend Engineer Payments Challenge.pdf](https://github.com/adamfriswell/TrueLayerBackendEngineerChallenge/blob/master/TrueLayer%20-%20Backend%20Engineer%20Payments%20Challenge.pdf) for full details.
API's used:
* [Pokemon API](https://pokeapi.co/)
* [Shakespear Translator](https://funtranslations.com/api/shakespeare)

## To run:
* Install the [dotnet sdk](https://dotnet.microsoft.com/en-us/download), I'm running v5.0.407 on my Macbook
* Serve the Swagger site by running `dotnet run` in the terminal, and navigate to /swagger endpoint to see the Swagger generated UI
* To run the tests run `dotnet test` in the terminal

## Implementation notes:
Here I am going to detail how I went about implementing my solution to this challenge:
* First I made a new dotnet webapi project, by running the `dotnet new webapi` command in the terminal, I then committed this to a new GitHub repo
* I added XUnit and related nuget package needed to write some unit tests, and made an empty `PokemonControllerTests.cs` class just to make sure the tests would run properly.
    * Using `dotnet test` to run the tests in the terminal.
    * I ran into the following error "CS0017: Program has more than one entry point defined." and found that the [solution](https://stackoverflow.com/questions/11747761/i-added-a-new-class-to-my-project-and-got-an-error-saying-program-main-has-mo) was to add `<GenerateProgramFile>false</GenerateProgramFile>` to the .csproj file.
* My first consideration for what this GET method should be doing is calling the prescribed PokeAPI to check that the given Pokemon name is actually a valid Pokemon. 
    * So I just called the `pokemon/{pokemonName}' endpoint of the PokeAPI and ensured this gave a valid response.
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
* More unit tests
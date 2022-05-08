# TrueLayer Backend Engineer Challenge:

## The challenge:
Write a RESTful Pokemon API with a GET method that returns a Shakespearean description for a given Pokemon name.
See [TrueLayer - Backend Engineer Payments Challenge.pdf](https://github.com/adamfriswell/TrueLayerBackendEngineerChallenge/blob/master/TrueLayer%20-%20Backend%20Engineer%20Payments%20Challenge.pdf) file for full details.
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
* Then I removed the boilerplate WeatherForecast code that was generated with the dotnet project
* I added XUnit and related nuget package needed to write some unit tests, and made an empty `PokemonControllerTests.cs` class just to make sure the tests would run properly.
    * Using `dotnet test` to run the tests in the terminal.
    * I ran into the following error "CS0017: Program has more than one entry point defined." and found that the [solution](https://stackoverflow.com/questions/11747761/i-added-a-new-class-to-my-project-and-got-an-error-saying-program-main-has-mo) was to add `<GenerateProgramFile>false</GenerateProgramFile>` to the .csproj file.
* My first consideration for what this GET method should be doing is calling the prescribed PokeAPI to check that the given Pokemon name is actually a valid Pokemon. 
    * So I just called the `pokemon/{pokemonName}' endpoint of the PokeAPI and ensured this gave a valid response.
* Next I wanted to get a description of the Pokemon in question to be able to translate into Shakespearean text.
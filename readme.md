# TrueLayer Backend Engineer Challenge:

## The challenge:
See [TrueLayer - Backend Engineer Payments Challenge.pdf](https://github.com/adamfriswell/TrueLayerBackendEngineerChallenge/blob/master/TrueLayer%20-%20Backend%20Engineer%20Payments%20Challenge.pdf) file

## To run:
* Install the [dotnet sdk](https://dotnet.microsoft.com/en-us/download), I'm running v5.0.407 on my Macbook
* Serve the Swagger site by running `dotnet run` in the terminal, and navigate to /swagger endpoint to see the Swagger generated UI
* To run the tests run `dotnet test` in the terminal

## Implementation notes:
Here I am going to detail how I went about implementing my solution to this challenge:
* First I made a new dotnet webapi project, by running the `dotnet new webapi` command in the terminal, I then committed this to a new GitHub repo
* Then I removed the boilerplate WeatherForecast code that was generated with the dotnet project
* I added XUnit and related nuget package needed to write some unit tests, and made an empty `PokemonControllerTests.cs` class just to make sure the tests would run properly. Using `dotnet test` to run the tests in the terminal.

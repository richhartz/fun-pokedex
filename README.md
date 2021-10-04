# Fun Pokedex

Fun Pokedex is an API written as a technical excercise that provides basic enpoints combining the existing APIs. https://pokeapi.co/ and https://api.funtranslations.com

## Built with.
.Net 5.

## How to Build and
Install the 5.0 SDK/runtime. You can download them from https://dotnet.microsoft.com/download/dotnet/5.0 

In order to run the project, clone or download the code and run using dotnet commands.

```
git clone https://github.com/richhartz/fun-pokedex

cd fun-pokedex
dotnet build .\Fun.Pokedex.Api.sln
dotnet .\Fun.Pokedex.Api\bin\Debug\net5.0\Fun.Pokedex.Api.dll
```

### Swagger - Open API EndPoint

The Swagger Open API is available on https://localhost:5001/swagger 

### Using curl
# pokemon/{name}
curl https://localhost:5001/pokemon/<name>

For example:
    curl https://localhost:5001/pokemon/mewtwo

# pokemon/translated/{name}
curl https://localhost:5001/pokemon/translated/<name>

For example:
    curl https://localhost:5001/pokemon/translated/mewtwo
```

### Running in the Docker

Ensure you have docker installed, or docker desktop for windows.

https://www.docker.com/products/docker-desktop

```
cd fun-pokedex

docker-compose up -d

```

## Changes for Production.
- Implement caching for the pokeapi data.
- Rate limiting to prevent denial of service attacks.
- Implement retries on external calls to improve resiliency. 
- Authentication if required.
- Create Nuget packages from logging and error handling projects and push to a private repo for reuse.
- Potentially prevent swagger from running outside of development environments.
- Add appliation to a CI/CD pipeline.
- Put the version used in swagger/logging into configuratio, replace version in build pipline.
- Implement integration tests.
- Pay for the translations API and add API key to the calls.
- Run tests on build
- Potentiallty add additional Sinks to logging e.g, AWS or Google, it currently just logs to the console for demonstration.
- Potentially heavier more verbose logging, I have opted not to log every request and response to the Poke and Translation API as the information is trivial.
 - Add middleware to include additional security headers to requests, depending on our required limitations, e.g X-Frame-Options, X-Content-Type-Options, X-XSS-Protection, Strict-Transport-Security
 - Remove any uneccessary headers that expose server information.



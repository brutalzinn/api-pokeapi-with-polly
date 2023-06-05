using PokeApi;
using PokeApi.Responses;
using Polly;
using RestEase;
using RestEase.HttpClientFactory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRestEaseClient<IPokeApi>("https://pokeapi.co/api");

var app = builder.Build();



app.MapGet("/", async (IPokeApi pokeApi) =>
{
    /// i dont will do anything because this route is just perfect
    var pokemon = await pokeApi.GetPokemonByName("pikachu");
    return Results.Ok(pokemon);
});


///except return a configurable default instance of PokemonResumeResponse
app.MapGet("/pikachu", async (IPokeApi pokeApi) =>
{
    /// but now i want when this routes dont responds with a success, I need to a fallback with a substitute value for property is_default
    /// The is_default is a property used by https://pokeapi.co/docs/v2#pokemon explains that "Set for exactly one Pokémon used as the default for each species."
    /// Pikachu is the best example to complain this as everytime true.
    /// I will put some pokemon that doesnt exists on poke api and this needs return a default the property. 
    /// Agumon is not a trully pokemon. This routes will gets a 404 and everytime i call this route, i need to return a model of PokemonResumeResponse with this property as true. 
    /// I really perfer digimon, guys :)
    var fallbackPolicity = Policy<PokemonResumeResponse>
    .Handle<ApiException>(ex => ex.StatusCode == System.Net.HttpStatusCode.NotFound)
    .Fallback<PokemonResumeResponse>(PokemonResumeResponse.Default)
    .ExecuteAndCapture(() => pokeApi.GetPokemonByName("agumon").GetAwaiter().GetResult());

    return Results.Ok(fallbackPolicity);
});



app.Run();

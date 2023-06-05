using PokeApi.Responses;
using RestEase;

namespace PokeApi
{

    public interface IPokeApi
    {

        [Get("/v2/pokemon/{pokemon}")]
        Task<PokemonResumeResponse> GetPokemonByName([Path] string pokemon);
    }
}
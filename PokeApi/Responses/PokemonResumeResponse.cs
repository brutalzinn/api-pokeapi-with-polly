using System.Text.Json.Serialization;
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
namespace PokeApi.Responses
{
    public class PokemonResumeResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("abilities")]
        public List<Ability> Abilities { get; set; }

        [JsonPropertyName("types")]
        public List<Type> Types { get; set; }

        public static PokemonResumeResponse Default()
        {
            return new PokemonResumeResponse()
            {
                IsDefault = true
            };
        }
    }
}
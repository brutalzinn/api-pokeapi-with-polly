using System.Text.Json.Serialization;
namespace PokeApi.Responses
{
    public class TypeDetail
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}

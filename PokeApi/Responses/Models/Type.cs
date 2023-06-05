using System.Text.Json.Serialization;
namespace PokeApi.Responses
{
    public class Type
    {
        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonPropertyName("type")]
        public TypeDetail Details { get; set; }
    }
}
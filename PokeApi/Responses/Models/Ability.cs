using System.Text.Json.Serialization;
namespace PokeApi.Responses
{
    public class Ability
    {
        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonPropertyName("ability")]
        public AbilityDetail Details { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace GigaChat.Requests.ChatCompletions.Models
{
    public class ChatCompletionsResponse
    {
        public Choices choices { get; set; }  = null!;
        public long created { get; set; }
        public string model { get; set; }  = null!;
        public TokenUsed usage { get; set; } = null!;
        [JsonPropertyName("object")]
        public string objectCall { get; set; } = null!;
    }
}
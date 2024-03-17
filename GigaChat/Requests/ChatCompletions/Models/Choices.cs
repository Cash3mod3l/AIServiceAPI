namespace GigaChat.Requests.ChatCompletions.Models
{
    public class Choices
    {
        ChatMessage message { get; set; } = null!;
        public int index { get; set; }
        public string finish_reason { get; set; } = null!;
    }
}
namespace GigaChat.Requests.ChatCompletions.Models
{
    public class ChatMessage
    {
        public string role { get; set; } = null!;
        public string content { get; set; } = null!;
    }
}
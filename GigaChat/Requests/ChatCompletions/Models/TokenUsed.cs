namespace GigaChat.Requests.ChatCompletions.Models
{
    public class TokenUsed
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
        public int system_tokens { get; set; }

    }
}
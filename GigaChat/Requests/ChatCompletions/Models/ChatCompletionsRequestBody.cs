namespace GigaChat.Requests.ChatCompletions.Models
{
    public class ChatCompletionsRequestBody
    {
        public string model { get; set; } = "GigaChat:latest";
        public ChatContext messages { get; set; } = null!;
        public float? temperature { get; set; }
        public float? top_p { get; set; }
        public long? n { get; set; }
        public bool? stream { get; set; }
        public long? max_tokens { get; set; }
        public float? repetition_penalty { get; set; }
        public uint? update_interval { get; set; }
    }
}

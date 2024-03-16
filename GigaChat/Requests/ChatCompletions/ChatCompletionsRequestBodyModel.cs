using GigaChat.Models;

namespace GigaChat.Requests.ChatCompletions
{
    public class ChatCompletionsRequestBodyModel
    {
        public ChatContext messages { get; set; } = null!;
    }
}

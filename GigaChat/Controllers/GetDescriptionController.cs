using GigaChat.Configs;
using GigaChat.Managers;
using GigaChat.Requests;
using GigaChat.Requests.AccessToken;
using GigaChat.Requests.ChatCompletions;
using GigaChat.Requests.ChatCompletions.Models;
using Microsoft.AspNetCore.Mvc;

namespace GigaChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDescriptionController : ControllerBase
    {
        private readonly GigaChatRestClient _gigaChatRestClient;
        private readonly AccessTokenManager _accessTokenManager;
        public GetDescriptionController(GigaChatRestClient gigaChatRestClient, AccessTokenManager accessTokenManager)
        {

            _gigaChatRestClient = gigaChatRestClient;
            _accessTokenManager = accessTokenManager;
            
        }

        private ChatContext generateChatContextFromEvent(string textEvent)
        {
            string content = $"Обьясни что это:\n\n{textEvent}";

            return new()
            {
                new()
                {
                    role = "user",
                    content = content
                }
            };
        }

        [HttpPost("")]
        public async Task<IActionResult> Get([FromBody] string textEvent)
        {
            ChatCompletionsRequest chatCompletionsRequest = new
            (
                _gigaChatRestClient,
                _accessTokenManager,
                generateChatContextFromEvent(textEvent)
            );

            string? answer = await chatCompletionsRequest.Send();
            if (answer is null)
            {
                return NoContent();
            }

            return Ok(answer);
        }
    }
}
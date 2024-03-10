using GigaChat.Configs;
using GigaChat.Managers;
using GigaChat.Requests.AccessToken;
using Microsoft.AspNetCore.Mvc;

namespace GigaChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDescriptionController : ControllerBase
    {
        private readonly AccessTokenManager _accessTokenManager;
        public GetDescriptionController(IConfiguration configuration)
        {
            GigaChatConfig config = configuration.Get<GigaChatConfig>() ?? throw new ArgumentNullException("");
            _accessTokenManager = new(
                new AccessTokenRestClient(config.ClientToken, GigaChatScopeTools.Of(config.AccessTokenScope))
            );

        }

        [HttpGet("/")]
        public IActionResult Get(string request)
        {
            return Ok(request);
        }
    }
}
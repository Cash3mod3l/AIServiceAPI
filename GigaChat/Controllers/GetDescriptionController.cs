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
        public GetDescriptionController(AccessTokenManager accessTokenManager)
        {
            _accessTokenManager = accessTokenManager;
        }

        [HttpGet("")]
        public IActionResult Get(string request)
        {
            return Ok(_accessTokenManager.AccessToken);
        }
    }
}
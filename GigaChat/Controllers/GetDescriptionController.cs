using Microsoft.AspNetCore.Mvc;

namespace GigaChat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetDescriptionController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get(string request)
        {
            return Ok(request);
        }
    }
}
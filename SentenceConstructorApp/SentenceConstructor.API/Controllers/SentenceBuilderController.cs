using Microsoft.AspNetCore.Mvc;

namespace SentenceConstructor.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SentenceBuilderController : ControllerBase
    {
        [HttpGet]
        public string GetInformation()
        {
            return "Hello World";
        }
    }
}

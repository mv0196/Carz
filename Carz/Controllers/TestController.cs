using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Carz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger logger;

        public TestController()
        {
            logger = Log.Logger;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            logger.Information("Index method called");
            return Ok("");
        }
    }
}

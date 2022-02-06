using Carz.IdentityService.Domain.Queries.Login;
using Carz.IdentityService.Domain.Responses.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Carz.IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IMediator _mediator;
        public LoginController(ILogger<LoginController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            LoginResponse res = await _mediator.Send(query);
            if(res == null)
            {
                return Unauthorized();
            }
            return Ok(res);
        }
    }
}

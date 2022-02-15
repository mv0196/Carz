using Carz.UserService.Domain.Commands;
using Carz.UserService.Domain.Queries;
using Carz.UserService.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Carz.UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(GetProfileByIdQuery query)
        {
            ProfileResponse res = await _mediator.Send(query);
            if(res!=null)
            {
                return Ok(res);
            }
            return NotFound();
        }

        [HttpGet("identity/{IdentityId}")]
        public async Task<IActionResult> GetByIdentityId(GetProfileByIdentityIdQuery query)
        {
            ProfileResponse res = await _mediator.Send(query);
            if(res!=null)
            {
                return Ok(res);
            }
            return NotFound();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProfile(CreateProfileCommand command)
        {
            ProfileResponse res = await _mediator.Send(command);
            if(res != null)
            {
                return Created($"{Request.Path}/{res.Id}",res);
            }
            return Conflict();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileCommand command)
        {
            ProfileResponse res = await _mediator.Send(command);
            if(res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }
    }
}

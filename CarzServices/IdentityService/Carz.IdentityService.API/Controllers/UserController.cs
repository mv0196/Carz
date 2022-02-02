using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.User;
using Carz.IdentityService.Domain.Responses.Role;
using Carz.IdentityService.Domain.Responses.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carz.IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /*
         *      AssignRoleToUserHandler.cs
                BlockUserHandler.cs
                CreateUserHandler.cs
                DisableUserHandler.cs
                EnableUserHandler.cs
                ForgotPasswordHandler.cs
                GetUserByIdHandler.cs
                GetUserRolesHandler.cs
                RevokeRoleFromUserHandler.cs
                UpdateUserHandler.cs
         */
        [HttpPost("assign")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleToUserCommand command)
        {
            bool res = await _mediator.Send(command);
            if (res == false)
                return BadRequest();
            return Ok();
        }

        [HttpPost("block")]
        public async Task<IActionResult> BlockUser([FromBody] BlockUserCommand command)
        {
            bool res = await _mediator.Send(command);
            if (res == false)
                return BadRequest();
            return Ok();
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserComand command)
        {
            UserResponse res = await _mediator.Send(command);
            if (res == null)
                return Conflict();
            return Created($"{Request.Path}/{res.Id}", res);
        }

        [HttpGet("disable/{Id}")]
        public async Task<IActionResult> DisableUser([FromRoute] DisableUserCommand command)
        {
            bool res = await _mediator.Send(command);
            if (res == false)
                return BadRequest();
            return Ok();
        }

        [HttpGet("enable/{Id}")]
        public async Task<IActionResult> EnableUser([FromRoute] EnableUserCommand command)
        {
            bool res = await _mediator.Send(command);
            if (res == false)
                return BadRequest();
            return Ok();
        }

        [HttpGet("forgotpassword/{Id}")]
        public async Task<IActionResult> ForgotPassword([FromRoute] ForgotPasswordQuery query)
        {
            //bool res = await _mediator.Send(query);
            //if (res == false)
            //    return BadRequest();
            return Ok();
        }

        [HttpGet("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        {
            bool res = await _mediator.Send(command);
            if (res == false)
                return BadRequest();
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUSerById([FromRoute] GetUserByIdQuery query)
        {
            UserResponse res = await _mediator.Send(query);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpGet("userroles/{Id}")]
        public async Task<IActionResult> GetUserRoles(GetUserRolesQuery query)
        {
            List<RoleResponse> roles = await _mediator.Send(query);
            if (roles == null)
                return NotFound();
            return Ok(roles);
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> RevokeRoleFromUser([FromBody] RevokeRoleFromUserCommand command)
        {
            bool res = await _mediator.Send(command);
            if (res == false)
                return BadRequest();
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            UserResponse res = await _mediator.Send(command);
            if (res == null)
                return NotFound();
            return Ok(res);
        }


    }
}

using AutoMapper;
using Carz.Common.Filters;
using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.DTO.User;
using Carz.IdentityService.Domain.Queries.User;
using Carz.IdentityService.Domain.Responses.Role;
using Carz.IdentityService.Domain.Responses.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [NonAction]
        private Guid GetUserIdFromContext()
        {
            Guid userId = Guid.Empty;
            Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value, out userId);
            return userId;
        }


        [HttpPost("assign")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleToUserCommandDTO request)
        {
            AssignRoleToUserCommand command = _mapper.Map<AssignRoleToUserCommand>(request);
            command.AssignedBy = GetUserIdFromContext();
            bool res = await _mediator.Send(command);
            if (res == false)
                return BadRequest();
            return Ok();
        }

        [HttpPost("block")]
        [Authorize("Admin")]
        public async Task<IActionResult> BlockUser([FromBody] BlockUserCommandDTO request)
        {
            BlockUserCommand command = _mapper.Map<BlockUserCommand>(request);
            command.BlockedBy = GetUserIdFromContext();
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
        public async Task<IActionResult> DisableUser([FromRoute] DisableUserCommandDTO request)
        {
            DisableUserCommand command = _mapper.Map<DisableUserCommand>(request);
            command.DisabledBy = GetUserIdFromContext();
            bool res = await _mediator.Send(command);
            if (res == false)
                return BadRequest();
            return Ok();
        }

        [HttpGet("enable/{Id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> EnableUser([FromRoute] EnableUserCommandDTO request)
        {
            EnableUserCommand command = _mapper.Map<EnableUserCommand>(request);
            command.EnabledBy = GetUserIdFromContext();
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
        public async Task<IActionResult> RevokeRoleFromUser([FromBody] RevokeRoleFromUserCommandDTO rquest)
        {
            RevokeRoleFromUserCommand command = _mapper.Map<RevokeRoleFromUserCommand>(Request);
            command.RevokedBy = GetUserIdFromContext();
            bool res = await _mediator.Send(command);
            if (res == false)
                return BadRequest();
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommandDTO request)
        {
            UpdateUserCommand command = _mapper.Map<UpdateUserCommand>(request);
            command.UpdatedBy = GetUserIdFromContext();
            command.UpdatedBy = GetUserIdFromContext();
            UserResponse res = await _mediator.Send(command);
            if (res == null)
                return NotFound();
            return Ok(res);
        }


    }
}

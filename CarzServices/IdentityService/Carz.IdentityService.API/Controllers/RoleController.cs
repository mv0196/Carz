using AutoMapper;
using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.DTO.Role;
using Carz.IdentityService.Domain.Queries.Role;
using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carz.IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RoleController(ILogger<RoleController> logger, IMediator mediator, IMapper mapper)
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


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommandDTO request)
        {
            CreateRoleCommand command = _mapper.Map<CreateRoleCommand>(request);
            command.CreatedBy = GetUserIdFromContext();

            RoleResponse res = await _mediator.Send(command);
            if(res == null)
            {
                return Conflict();
            }
            return Created($"{Request.Path}/{res.Id}", res);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteRoleCommandDTO request)
        {
            DeleteRoleCommand command = _mapper.Map<DeleteRoleCommand>(request);
            command.DeletedBy = GetUserIdFromContext();
            bool res = await _mediator.Send(command);
            if (res == false)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromBody] GetAllRolesQuery query)
        {
            List<RoleResponse> res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoleCommandDTO request)
        {
            UpdateRoleCommand command = _mapper.Map<UpdateRoleCommand>(request);
            command.UpdatedBy = GetUserIdFromContext();
            RoleResponse res = await _mediator.Send(command);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}

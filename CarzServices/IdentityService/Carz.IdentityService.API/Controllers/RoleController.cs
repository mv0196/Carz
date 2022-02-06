using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.Queries.Role;
using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
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
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMediator _mediator;
        public RoleController(ILogger<RoleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
        {
            StringValues adminIdValue = new StringValues("");
            Request.Headers.TryGetValue("AdminId", out adminIdValue);

            string adminId = adminIdValue.ToString();

            Guid adminGuid = Guid.Empty;
            Guid.TryParse(adminId, out adminGuid);

            command.AdminId = adminGuid;

            RoleResponse res = await _mediator.Send(command);
            if(res == null)
            {
                return Conflict();
            }
            return Created($"{Request.Path}/{res.Id}", res);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteRoleCommand command)
        {
            bool res = await _mediator.Send(command);
            if (res == false)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromBody] GetAllRolesQuery query)
        {
            List<RoleResponse> res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoleCommand command)
        {
            RoleResponse res = await _mediator.Send(command);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}

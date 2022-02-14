using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.DTO.Role
{
    public class CreateRoleCommandDTO : IRequest<RoleResponse>
    {
        public string Name { get; set; }
    }
}

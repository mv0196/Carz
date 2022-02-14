using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.DTO.Role
{
    public class UpdateRoleCommandDTO : IRequest<RoleResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

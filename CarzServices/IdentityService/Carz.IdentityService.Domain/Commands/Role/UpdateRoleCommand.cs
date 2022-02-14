using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class UpdateRoleCommand : IRequest<RoleResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}

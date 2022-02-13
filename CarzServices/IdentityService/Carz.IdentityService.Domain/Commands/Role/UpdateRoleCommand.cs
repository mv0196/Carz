using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class UpdateRoleCommand : IRequest<RoleResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PerformedBy { get; set; }
    }
}

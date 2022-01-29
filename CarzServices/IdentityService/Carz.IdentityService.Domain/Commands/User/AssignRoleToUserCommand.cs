using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class AssignRoleToUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
    }
}

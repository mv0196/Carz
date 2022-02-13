using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class RevokeRoleFromUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        // Admin which is blocking
        public Guid PerformedBy { get; set; }
    }
}

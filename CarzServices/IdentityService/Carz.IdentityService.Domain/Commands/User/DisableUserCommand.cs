using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class DisableUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        // Admin which is blocking
        public Guid PerformedBy { get; set; }
    }
}

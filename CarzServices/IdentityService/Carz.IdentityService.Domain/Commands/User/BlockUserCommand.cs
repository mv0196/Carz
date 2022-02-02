using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class BlockUserCommand : IRequest<bool>
    {
        // User to block
        public Guid Id { get; set; }

        // Admin which is blocking
        public Guid AdminId { get; set; }
    }
}

using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class BlockUserCommand : IRequest<bool>
    {
        // User to block
        public Guid Id { get; set; }

        public Guid BlockedBy { get; set; }
    }
}

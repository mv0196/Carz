using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class DisableUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        // Admin which is blocking
        public Guid DisabledBy { get; set; }
    }
}

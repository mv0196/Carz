using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class BlockUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

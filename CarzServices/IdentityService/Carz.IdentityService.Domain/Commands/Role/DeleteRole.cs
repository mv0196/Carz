using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class DeleteRole : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

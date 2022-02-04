using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid AdminId { get; set; }
    }
}

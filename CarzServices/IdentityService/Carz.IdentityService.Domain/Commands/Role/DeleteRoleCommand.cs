using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid DeletedBy { get; set; }
    }
}

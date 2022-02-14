using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.DTO.User
{
    public class RevokeRoleFromUserCommandDTO : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
    }
}

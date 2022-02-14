using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.DTO.Role
{
    public class DeleteRoleCommandDTO : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.DTO.User
{
    public class BlockUserCommandDTO : IRequest<bool>
    {
        // User to block
        public Guid Id { get; set; }
    }
}

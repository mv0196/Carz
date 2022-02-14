using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.DTO.User
{
    public class EnableUserCommandDTO : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

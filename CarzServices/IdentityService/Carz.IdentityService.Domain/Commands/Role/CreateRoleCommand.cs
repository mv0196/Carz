using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class CreateRoleCommand : IRequest<RoleResponse>
    {
        public string Name { get; set; }
        [JsonIgnore]
        public Guid AdminId { get; set; }
    }
}

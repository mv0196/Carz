using Carz.IdentityService.Domain.Responses.Role;
using MediatR;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class CreateRoleCommand : IRequest<RoleResponse>
    {
        public string Name { get; set; }
    }
}

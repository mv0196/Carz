using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System.Collections.Generic;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class GetAllRoles : IRequest<List<RoleResponse>>
    {
    }
}

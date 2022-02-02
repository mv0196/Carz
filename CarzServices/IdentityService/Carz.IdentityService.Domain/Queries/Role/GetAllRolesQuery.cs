using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System.Collections.Generic;

namespace Carz.IdentityService.Domain.Queries.Role
{
    public class GetAllRolesQuery : IRequest<List<RoleResponse>>
    {
    }
}

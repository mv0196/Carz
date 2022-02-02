using Carz.IdentityService.Domain.Queries.Role;
using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.Role
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, List<RoleResponse>>
    {
        public Task<List<RoleResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

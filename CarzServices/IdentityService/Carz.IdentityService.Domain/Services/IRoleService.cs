using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.Role;
using Carz.IdentityService.Domain.Responses.Role;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Services
{
    public interface IRoleService
    {
        // Commands
        Task<Role> CreateRole(CreateRoleCommand command, CancellationToken cancellationToken = default);
        Task<Role> UpdateRole(UpdateRoleCommand command, CancellationToken cancellationToken = default);
        Task<bool> DeleteRole(DeleteRoleCommand command, CancellationToken cancellationToken = default);

        // Queries
        Task<List<Role>> GetAllRoles(GetAllRolesQuery query, CancellationToken cancellationToken = default);
    }
}

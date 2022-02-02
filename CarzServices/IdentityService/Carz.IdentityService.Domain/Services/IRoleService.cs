using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.Role;
using Carz.IdentityService.Domain.Responses.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Services
{
    public interface IRoleService
    {
        // Commands
        Task<Role> CreateRole(CreateRoleCommand command);
        Task<Role> UpdateRole(UpdateRoleCommand command);
        Task<bool> DeleteRole(DeleteRoleCommand command);

        // Queries
        Task<List<Role>> GetAllRoles(GetAllRolesQuery query);
    }
}

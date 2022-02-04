using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.Role;
using Carz.IdentityService.Domain.Services;
using Carz.IdentityService.Services.SQL.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Services.SQL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IdentityUserDbContext _context;

        public RoleService(IdentityUserDbContext context)
        {
            _context = context;
        }
        public async Task<Role> CreateRole(CreateRoleCommand command, CancellationToken cancellationToken = default)
        {
            Role role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == command.Name);

            // Already exists
            if (role != null)
                return null;

            role = new Role
            {
                Name = command.Name
            };

            await _context.Roles.AddAsync(role);

            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRole(DeleteRoleCommand command, CancellationToken cancellationToken = default)
        {
            Role role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == command.Id);

            // do not exists
            if (role == null)
                return false;

            bool inUse = await _context.IdentityUserRoles.AnyAsync(r => r.RoleId == command.Id);

            // Someone has this role
            if (inUse)
                return false;

            _context.Roles.Remove(role);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Role>> GetAllRoles(GetAllRolesQuery query, CancellationToken cancellationToken = default)
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> UpdateRole(UpdateRoleCommand command, CancellationToken cancellationToken = default)
        {
            Role role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == command.Id);

            // do not exists
            if (role == null)
                return null;

            role.Name = command.Name;

            await _context.SaveChangesAsync();

            return role;
        }
    }
}

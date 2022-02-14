using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.User;
using Carz.IdentityService.Domain.Services;
using Carz.IdentityService.Services.SQL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Services.SQL.Services
{
    public class UserService : IUserService
    {
        private readonly IdentityUserDbContext _context;

        public UserService(IdentityUserDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AssignRoleToUser(AssignRoleToUserCommand command, CancellationToken cancellationToken = default)
        {
            IdentityUserRole role = await _context.IdentityUserRoles.FirstOrDefaultAsync(ur => ur.IdentityUserId == command.Id && ur.RoleId == command.RoleId);
            if (role != null)
                return false;

            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Id == command.Id);
            if (user == null || user.Blocked || user.Disabled)
                return false;

            await _context.IdentityUserRoles.AddAsync(new IdentityUserRole
            {
                IdentityUserId = command.Id,
                RoleId = command.RoleId
            });

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BlockUser(BlockUserCommand command, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Id == command.Id);

            // User do not exists
            if (user == null)
                return false;
            user.Blocked = true;
            user.BlockedAt = DateTime.Now;
            user.BlockedPublished = false;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IdentityUser> CreateUser(CreateUserComand command, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Email == command.Email);

            // Email already exists
            if (user != null)
                return null;

            string passwordSalt = "";// get from service
            string passwordHash = command.Password;// get from service

            user = new IdentityUser
            {
                Email = command.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                CreatedPublished = false
            };

            await _context.IdentityUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DisableUser(DisableUserCommand command, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Id == command.Id);

            // user not exists
            if (user == null)
                return false;

            user.Disabled = true;
            user.DisablededAt = DateTime.Now;
            user.DisabledPublished = false;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EnableUser(EnableUserCommand command, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Id == command.Id);

            // user not exists
            if (user == null)
                return false;

            user.Disabled = false;
            user.EnablededAt = DateTime.Now;
            user.EnabledPublished = false;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ForgotPassword(ForgotPasswordCommand command, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Id == command.Id);

            // user not exists
            if (user == null)
                return false;

            string passwordSalt = "";// get from service
            string passwordHash = command.Password;// get from service

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            user.PasswordChangedPublished = false;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task ForgotPassword(ForgotPasswordQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> GetIdByEmail(GetIdByEmailQuery query, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Email == query.Email);

            // user not exists
            if (user == null)
                return Guid.Empty;

            return user.Id;
        }

        public async Task<IdentityUser> GetUserById(GetUserByIdQuery query, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Id == query.Id);

            // user not exists
            if (user == null)
                return null;

            return user;
        }

        public async Task<List<Role>> GetUserRoles(GetUserRolesQuery query, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Id == query.Id);

            // user not exists
            if (user == null)
                return null;

            return await _context.IdentityUserRoles.Where(ur => ur.IdentityUserId == query.Id).Select(r => r.Role).ToListAsync();
        }

        public async Task<List<Role>> GetUserRolesByEmail(GetUserRolesByEmailQuery query, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Email == query.Email);

            // user not exists
            if (user == null)
                return null;

            return await _context.IdentityUserRoles.Where(ur => ur.IdentityUserId == user.Id).Select(r => r.Role).ToListAsync();
        }

        public async Task<bool> RevokeRoleFromUser(RevokeRoleFromUserCommand command, CancellationToken cancellationToken = default)
        {
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Id == command.Id);

            // user not exists
            if (user == null)
                return false;

            IdentityUserRole role = await _context.IdentityUserRoles.FirstOrDefaultAsync(ur => ur.IdentityUserId == command.Id && ur.RoleId == command.RoleId);

            if (role == null)
                return false;

            _context.IdentityUserRoles.Remove(role);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IdentityUser> UpdateUser(UpdateUserCommand command, CancellationToken cancellationToken = default)
        {
            // Seems like there is nothing user can update. Most probably we don't want user to change email
            throw new NotImplementedException();
        }
    }
}

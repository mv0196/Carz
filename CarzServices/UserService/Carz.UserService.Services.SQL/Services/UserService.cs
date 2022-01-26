using Carz.UserService.Domain.Entities;
using Carz.UserService.Domain.Services;
using Carz.UserService.Services.SQL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.UserService.Services.SQL.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateProfile(User user, CancellationToken cancellationToken = default)
        {
            User existingUser = await _context.Users.FirstOrDefaultAsync(u => u.IdentityId == user.IdentityId).ConfigureAwait(false);
            if (existingUser != null)
                return null;
            await _context.Users.AddAsync(user, cancellationToken);
            return user;
        }

        public async Task<User> GetProfileById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id).ConfigureAwait(false);
        }

        public async Task<User> GetProfileByIdentityId(Guid identityId, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.IdentityId == identityId).ConfigureAwait(false);
        }

        public async Task<User> UpdateProfile(Guid identityId, User user, CancellationToken cancellationToken = default)
        {
            User existingUser = await _context.Users.FirstOrDefaultAsync(u => u.IdentityId == identityId).ConfigureAwait(false);
            if (existingUser == null)
                return null;

            existingUser.Name = user.Name;
            existingUser.Aadhaar = user.Aadhaar;
            existingUser.Address = user.Address;
            existingUser.ContactNum = user.ContactNum;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.UpdatedAt = DateTime.Now;
            existingUser.UpdatedPublished = false;

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}

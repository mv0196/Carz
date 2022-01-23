using Carz.UserService.Domain.Entities;
using Carz.UserService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.UserService.Services.SQL.Services
{
    public class UserService : IUserService
    {
        public Task<User> CreateProfile(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetProfileById(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetProfileByIdentityId(Guid identityId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateProfile(Guid id, User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

using Carz.UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.UserService.Domain.Services
{
    public interface IUserService
    {
        Task<User> CreateProfile(User user, CancellationToken cancellationToken = default);
        Task<User> UpdateProfile(Guid id, User user, CancellationToken cancellationToken = default);
        Task<User> GetProfileById(Guid id, CancellationToken cancellationToken = default);
        Task<User> GetProfileByIdentityId(Guid identityId, CancellationToken cancellationToken = default);
    }
}

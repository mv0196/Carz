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
        Task<User> Create(User user, CancellationToken cancellationToken = default);
        Guid Delete(User user, CancellationToken cancellationToken = default);
        Task<User> Update(Guid id, User user, CancellationToken cancellationToken = default);
        Task<User> GetById(Guid id, CancellationToken cancellationToken = default);
    }
}

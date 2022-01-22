using Carz.UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.UserService.Domain.Services
{
    public interface IRoleService
    {
        Task<Role> Create(Role role, CancellationToken cancellationToken = default);
        Task<Role> Update(Role role, CancellationToken cancellationToken = default);
        Task<int> Delete(int id, CancellationToken cancellationToken = default);
    }
}

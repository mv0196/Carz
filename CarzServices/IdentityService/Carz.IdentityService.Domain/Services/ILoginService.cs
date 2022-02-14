using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.Login;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Services
{
    public interface ILoginService
    {
        // Query
        Task<string> Login(LoginQuery query, CancellationToken cancellationToken = default);

        // helper function
        string GenerateToken(IdentityUser user);
    }
}

using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.Login;
using Carz.IdentityService.Domain.Responses.Login;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Services
{
    public interface ILoginService
    {
        // Query
        Task<string> Login(LoginQuery query);

        // helper function
        string GenerateToken(IdentityUser user);
    }
}

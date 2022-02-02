using Carz.IdentityService.Domain.Queries.Login;
using Carz.IdentityService.Domain.Responses.Login;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        public Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

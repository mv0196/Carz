using Carz.IdentityService.Domain.Responses.Login;
using MediatR;

namespace Carz.IdentityService.Domain.Queries.Login
{
    public class LoginQuery : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

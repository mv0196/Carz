using Carz.IdentityService.Domain.Responses.User;
using MediatR;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class CreateUserComand : IRequest<UserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

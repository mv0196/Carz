using Carz.IdentityService.Domain.Responses.User;
using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class UpdateUserCommand : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

using Carz.IdentityService.Domain.Responses.User;
using MediatR;
using System;

namespace Carz.IdentityService.Domain.DTO.User
{
    public class UpdateUserCommandDTO : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

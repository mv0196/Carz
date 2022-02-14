using Carz.IdentityService.Domain.Responses.User;
using MediatR;
using System;

namespace Carz.IdentityService.Domain.Queries.User
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
    }
}

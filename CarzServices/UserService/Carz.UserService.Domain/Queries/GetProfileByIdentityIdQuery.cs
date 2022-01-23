using Carz.UserService.Domain.Responses;
using MediatR;
using System;

namespace Carz.UserService.Domain.Queries
{
    public class GetProfileByIdentityIdQuery : IRequest<ProfileResponse>
    {
        public Guid IdentityId { get; set; }
    }
}

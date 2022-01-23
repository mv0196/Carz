using Carz.UserService.Domain.Responses;
using MediatR;
using System;

namespace Carz.UserService.Domain.Queries
{
    public class GetProfileByIdQuery : IRequest<ProfileResponse>
    {
        public Guid Id { get; set; }
    }
}

using Carz.UserService.Domain.Responses;
using MediatR;
using System;

namespace Carz.UserService.Domain.Commands
{
    public class UpdateProfileCommand : IRequest<ProfileResponse>
    {
        public Guid IdentityId { set; get; }
        public string Name { get; set; }
        public string Aadhaar { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNum { get; set; }
        public string Address { get; set; }
    }
}

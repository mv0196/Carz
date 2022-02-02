using AutoMapper;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Responses.User;

namespace Carz.IdentityService.Infrastructure.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<IdentityUser, UserResponse>();
        }
    }
}

using AutoMapper;
using Carz.UserService.Domain.Commands;
using Carz.UserService.Domain.Entities;
using Carz.UserService.Domain.Responses;

namespace Carz.UserService.Infrastructure.Mappers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<CreateProfileCommand, User>();
            CreateMap<UpdateProfileCommand, User>();
            CreateMap<User, ProfileResponse>();
        }
    }
}

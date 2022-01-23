using AutoMapper;
using Carz.UserService.Domain.Commands;
using Carz.UserService.Domain.Entities;
using Carz.UserService.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.UserService.Infrastructure.Mappers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<CreateProfileCommand, User>();
            CreateMap<User, ProfileResponse>();
        }
    }
}

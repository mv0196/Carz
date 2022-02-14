using AutoMapper;
using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.DTO.User;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Responses.User;

namespace Carz.IdentityService.Infrastructure.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<IdentityUser, UserResponse>();
            CreateMap<AssignRoleToUserCommandDTO, AssignRoleToUserCommand>().ForMember(dest => dest.AssignedBy, opt => opt.Ignore());
            CreateMap<BlockUserCommandDTO, BlockUserCommand>().ForMember(dest => dest.BlockedBy, opt => opt.Ignore());
            CreateMap<DisableUserCommandDTO, DisableUserCommand>().ForMember(dest => dest.DisabledBy, opt => opt.Ignore());
            CreateMap<EnableUserCommandDTO, EnableUserCommand>().ForMember(dest => dest.EnabledBy, opt => opt.Ignore());
            CreateMap<RevokeRoleFromUserCommandDTO, RevokeRoleFromUserCommand>().ForMember(dest => dest.RevokedBy, opt => opt.Ignore());
            CreateMap<UpdateUserCommandDTO, UpdateUserCommand>().ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());
        }
    }
}

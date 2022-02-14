using AutoMapper;
using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.DTO.Role;
using Carz.IdentityService.Domain.Responses.Role;

namespace Carz.IdentityService.Infrastructure.Mappers
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Domain.Entities.Role, RoleResponse>();
            CreateMap<DeleteRoleCommandDTO, DeleteRoleCommand>().ForMember(dest => dest.DeletedBy, opt => opt.Ignore());
            CreateMap<UpdateRoleCommandDTO, UpdateRoleCommand>().ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());
        }
    }
}

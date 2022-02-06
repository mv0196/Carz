using AutoMapper;
using Carz.IdentityService.Domain.Responses.Role;

namespace Carz.IdentityService.Infrastructure.Mappers
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Domain.Entities.Role, RoleResponse>();
        }
    }
}

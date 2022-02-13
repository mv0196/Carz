using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Advertisement;
using Carz.AdvertisementService.Domain.DTO.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Infrastructure.Mappers
{
    public class AdMapper : Profile
    {
        public AdMapper()
        {
            CreateMap<BlockAdCommandDTO, BlockAdCommand>().ForMember(dest => dest.PerformedBy, opt => opt.Ignore());
            CreateMap<CloseAdCommandDTO, CloseAdCommand>().ForMember(dest => dest.ClosedBy, opt => opt.Ignore());
            CreateMap<CreateAdCommandDTO, CreateAdCommand>().ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<EnableAdCommandDTO, EnableAdCommand>().ForMember(dest => dest.PerformedBy, opt => opt.Ignore());
            CreateMap<DisableAdCommandDTO, DisableAdCommand>().ForMember(dest => dest.DisabledBy, opt => opt.Ignore());
            CreateMap<UpdateAdCommandDTO, UpdateAdCommand>().ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());
        }
    }
}

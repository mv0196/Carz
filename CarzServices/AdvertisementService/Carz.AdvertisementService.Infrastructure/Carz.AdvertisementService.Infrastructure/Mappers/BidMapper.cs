using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Bid;
using Carz.AdvertisementService.Domain.DTO.RequestDTO.Bid;
using Carz.AdvertisementService.Domain.Queries.Bid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Infrastructure.Mappers
{
    public class BidMapper : Profile
    {
        public BidMapper()
        {
            CreateMap<GetAllBidsByUserQueryDTO, GetAllBidsByUserQuery>().ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<GetWonBidsByUserQueryDTO, GetWonBidsByUserQuery>().ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<PlaceBidCommandDTO, PlaceBidCommand>().ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<RemoveBidCommandDTO, RemoveBidCommand>().ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<UpdateBidCommandDTO, UpdateBidCommand>().ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}

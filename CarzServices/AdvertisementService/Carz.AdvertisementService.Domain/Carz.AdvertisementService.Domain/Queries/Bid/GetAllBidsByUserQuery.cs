using Carz.AdvertisementService.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace Carz.AdvertisementService.Domain.Queries.Bid
{
    public class GetAllBidsByUserQuery : IRequest<List<BidResponse>>
    {
        public Guid AdvertisementId { get; set; }
        public Guid UserId { get; set; }
    }
}

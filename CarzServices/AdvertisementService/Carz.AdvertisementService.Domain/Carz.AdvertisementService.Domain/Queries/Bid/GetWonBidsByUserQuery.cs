using Carz.AdvertisementService.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace Carz.AdvertisementService.Domain.Queries.Bid
{
    public class GetWonBidsByUserQuery : IRequest<List<BidResponse>>
    {
        public Guid UserId { get; set; }
    }
}

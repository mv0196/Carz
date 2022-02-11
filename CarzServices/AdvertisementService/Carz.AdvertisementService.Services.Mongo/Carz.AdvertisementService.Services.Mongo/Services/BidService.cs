using Carz.AdvertisementService.Domain.Commands.Bid;
using Carz.AdvertisementService.Domain.Entities;
using Carz.AdvertisementService.Domain.Queries.Bid;
using Carz.AdvertisementService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Services.Mongo.Services
{
    public class BidService : IBidService
    {
        public Task<List<Bid>> GetAllBidsByUser(GetAllBidsByUserQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bid>> GetWonBidsByUser(GetWonBidsByUserQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Bid> PlaceBid(PlaceBidCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveBid(RemoveBidCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Bid> UpdateBid(UpdateBidCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

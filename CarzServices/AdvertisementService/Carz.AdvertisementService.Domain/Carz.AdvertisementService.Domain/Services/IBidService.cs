using Carz.AdvertisementService.Domain.Commands.Bid;
using Carz.AdvertisementService.Domain.Entities;
using Carz.AdvertisementService.Domain.Queries.Bid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Services
{
    public interface IBidService
    {
        Task<List<Bid>> GetAllBidsByUser(GetAllBidsByUserQuery query, CancellationToken cancellationToken = default);
        Task<List<Bid>> GetWonBidsByUser(GetWonBidsByUserQuery query, CancellationToken cancellationToken = default);
        Task<Bid> PlaceBid(PlaceBidCommand command, CancellationToken cancellationToken = default);
        Task<bool> RemoveBid(RemoveBidCommand command, CancellationToken cancellationToken = default);
        Task<Bid> UpdateBid(UpdateBidCommand command, CancellationToken cancellationToken = default);
    }
}

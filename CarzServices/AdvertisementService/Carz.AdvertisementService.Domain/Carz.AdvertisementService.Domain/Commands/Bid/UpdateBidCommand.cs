using Carz.AdvertisementService.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Commands.Bid
{
    public class UpdateBidCommand : IRequest<BidResponse>
    {
        public Guid Id { get; set; }
        public Guid AdvertisementId { get; set; }
        public Guid UserId { get; set; }
        public double Price { get; set; }
    }
}

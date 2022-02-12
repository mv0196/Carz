using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Commands.Advertisement
{
    // Make a bid win
    public class CloseAdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid BidId { get; set; }
        public Guid UserId { get; set; }

    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Commands.Bid
{
    public class RemoveBidCommand : IRequest<bool>
    {
        public Guid AdvertisementId { get; set; }
        public Guid UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.DTO.RequestDTO.Bid
{
    public class PlaceBidCommandDTO
    {
        public Guid AdvertisementId { get; set; }
        public double Price { get; set; }
    }
}

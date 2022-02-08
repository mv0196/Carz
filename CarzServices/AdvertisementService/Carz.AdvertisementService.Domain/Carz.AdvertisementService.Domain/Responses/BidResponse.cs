using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Responses
{
    public class BidResponse
    {
        public Guid Id { get; set; }
        public Guid AdvertisementId { get; set; }
        public Guid UserId { get; set; }
        public double Price { get; set; }
        public bool Won { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

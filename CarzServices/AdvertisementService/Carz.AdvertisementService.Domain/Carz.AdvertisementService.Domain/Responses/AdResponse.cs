using Carz.AdvertisementService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Responses
{
    public class AdResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Ownership { get; set; }
        public double AskPrice { get; set; }
        public List<Bid> Bids { get; set; }
        public Guid Buyer { get; set; }
        public bool Enabled { get; set; }
        public bool Closed { get; set; }
        public bool Blocked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

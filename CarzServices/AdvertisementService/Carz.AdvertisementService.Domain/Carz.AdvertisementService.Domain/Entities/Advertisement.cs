using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Carz.AdvertisementService.Domain.Entities
{
    public class Advertisement
    {

        [BsonId]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Ownership { get; set; }
        public double AskPrice { get; set; }
        public List<Bid> Bids { get; set; }
        public Guid Buyer { get; set; } = Guid.Empty;
        public bool Enabled { get; set; } = true;
        public bool Closed { get; set; } = false;
        public bool Blocked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Guid UpdatedBy { get; set; }
        public bool CreatedPublished { get; set; } = true;
        public bool UpdatedPublished { get; set; } = true;
        public bool EnabledPublished { get; set; } = true;
        public bool DisabledPublished { get; set; } = true;
        public bool ClosedPublished { get; set; } = true;
        public bool BlockedPublished { get; set; } = true;
    }
}

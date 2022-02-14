using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Carz.AdvertisementService.Domain.Entities
{
    public class Bid
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid AdvertisementId { get; set; }
        public Guid UserId { get; set; }
        public double Price { get; set; }
        public bool Won { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Guid UpdatedBy { get; set; }
        public bool CreatedPublished { get; set; } = true;
        public bool UpdatedPublished { get; set; } = true;
    }
}

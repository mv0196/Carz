using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Entities
{
    public class Advertisement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        [ForeignKey("HealthStatusType")]
        public Guid Status { get; set; }
        [ForeignKey("OwnershipType")]
        public Guid Ownership { get; set; }
        public double AskPrice { get; set; }
        public List<Bid> Bids { get; set; }
        public Guid Buyer { get; set; } = Guid.Empty;
        [DefaultValue(true)]
        public bool Enabled { get; set; }
        [DefaultValue(false)]
        public bool Closed { get; set; }
        [DefaultValue(false)]
        public bool Blocked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [DefaultValue(true)]
        public bool CreatedPublished { get; set; }
        [DefaultValue(true)]
        public bool UpdatedPublished { get; set; }
        [DefaultValue(true)]
        public bool EnabledPublished { get; set; }
        [DefaultValue(true)]
        public bool DisabledPublished { get; set; }
        [DefaultValue(true)]
        public bool ClosedPublished { get; set; }
        [DefaultValue(true)]
        public bool BlockedPublished { get; set; }

        // Navigation property for StatusId
        public HealthStatus HealthStatusType { get; set; }
        public Ownership OwnershipType { get; set; }
    }
}

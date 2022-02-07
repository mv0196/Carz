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
    public class Bid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid AdvertisementId { get; set; }
        public Guid UserID { get; set; }
        public double Price { get; set; }
        public bool Won { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [DefaultValue(true)]
        public bool CreatedPublished { get; set; }
        [DefaultValue(true)]
        public bool UpdatedPublished { get; set; }
    }
}

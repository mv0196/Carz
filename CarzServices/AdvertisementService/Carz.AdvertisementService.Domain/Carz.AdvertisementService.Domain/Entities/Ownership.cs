using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carz.AdvertisementService.Domain.Entities
{
    // This class is just to get values to show dropdown
    public class Ownership
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

using Carz.AdvertisementService.Domain.Entities;
using System;

namespace Carz.AdvertisementService.Domain.DTO.RequestDTO
{
    // It do not have updatedBy because it will be later set in controller
    public class UpdateAdCommandDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Ownership { get; set; }
        public double AskPrice { get; set; }
        public Variant Variant { get; set; }
    }
}

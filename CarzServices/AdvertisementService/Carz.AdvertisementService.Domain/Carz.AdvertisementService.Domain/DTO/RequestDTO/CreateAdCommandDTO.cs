using Carz.AdvertisementService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.DTO.RequestDTO
{
    // It do not have CreatedBy and UpdatedBy because it will be later set in controller by extracting from Token
    public class CreateAdCommandDTO
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public string Ownership { get; set; }
        public double AskPrice { get; set; }
        public Variant Variant { get; set; }
    }
}

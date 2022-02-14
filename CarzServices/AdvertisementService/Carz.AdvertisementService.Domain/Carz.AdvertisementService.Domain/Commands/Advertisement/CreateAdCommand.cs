using Carz.AdvertisementService.Domain.Entities;
using Carz.AdvertisementService.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Commands.Advertisement
{
    public class CreateAdCommand : IRequest<AdResponse>
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Ownership { get; set; }
        public double AskPrice { get; set; }
        public Variant Variant { get; set; }
    }
}

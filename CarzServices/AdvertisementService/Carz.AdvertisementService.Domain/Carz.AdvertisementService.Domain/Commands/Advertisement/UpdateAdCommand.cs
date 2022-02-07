using Carz.AdvertisementService.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Commands.Advertisement
{
    public class UpdaetAdCommand : IRequest<AdResponse>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid Status { get; set; }
        public Guid Ownership { get; set; }
        public double AskPrice { get; set; }
    }
}

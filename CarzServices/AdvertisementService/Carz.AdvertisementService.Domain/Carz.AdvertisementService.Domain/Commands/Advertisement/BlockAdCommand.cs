using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Domain.Commands.Advertisement
{
    public class BlockAdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid AdminId { get; set; }
    }
}

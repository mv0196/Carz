using Carz.AdvertisementService.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace Carz.AdvertisementService.Domain.Queries.Advertisement
{
    public class GetClosedAdsQuery : IRequest<List<AdResponse>>
    {
        public Guid PerformedBy { get; set; }
    }
}

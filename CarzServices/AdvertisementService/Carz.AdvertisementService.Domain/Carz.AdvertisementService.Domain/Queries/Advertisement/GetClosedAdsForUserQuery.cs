using Carz.AdvertisementService.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace Carz.AdvertisementService.Domain.Queries.Advertisement
{
    public class GetClosedAdsForUserQuery : IRequest<List<AdResponse>>
    {
        public Guid UserId { get; set; }
    }
}

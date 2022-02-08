using MediatR;
using System;
using System.Collections.Generic;

namespace Carz.AdvertisementService.Domain.Queries.Advertisement
{
    public class GetActiveAdsForUserQuery : IRequest<List<AdResponse>>
    {
        public Guid UserId { get; set; }
    }
}

using Carz.AdvertisementService.Domain.Responses;
using MediatR;
using System.Collections.Generic;

namespace Carz.AdvertisementService.Domain.Queries.Advertisement
{
    public class GetActiveAdsQuery : IRequest<List<AdResponse>>
    {
    }
}

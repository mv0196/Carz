using AutoMapper;
using Carz.AdvertisementService.Domain.Queries.Advertisement;
using Carz.AdvertisementService.Domain.Responses;
using Carz.AdvertisementService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Infrastructure.Handlers.Advertisement
{
    class GetClosedAdsForUserHandler : IRequestHandler<GetClosedAdsForUserQuery, List<AdResponse>>
    {
        private readonly ILogger<GetClosedAdsForUserHandler> _logger;
        private readonly IAdService _service;
        private readonly IMapper _mapper;

        public GetClosedAdsForUserHandler(ILogger<GetClosedAdsForUserHandler> logger, IAdService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<List<AdResponse>> Handle(GetClosedAdsForUserQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Advertisement> ads = await _service.GetClosedAdsForUser(request, cancellationToken);
            _logger.LogInformation("Got {Advertisements} Closed advertisements for user {UserId}", ads.Count, request.UserId);
            return _mapper.Map<List<AdResponse>>(ads);
        }
    }
}

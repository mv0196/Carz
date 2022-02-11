using AutoMapper;
using Carz.AdvertisementService.Domain.Queries.Advertisement;
using Carz.AdvertisementService.Domain.Responses;
using Carz.AdvertisementService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Infrastructure.Handlers.Advertisement
{
    public class GetActiveAdsForUserHandler : IRequestHandler<GetActiveAdsForUserQuery, List<AdResponse>>
    {
        private readonly ILogger<GetActiveAdsForUserHandler> _logger;
        private readonly IAdService _service;
        private readonly IMapper _mapper;

        public GetActiveAdsForUserHandler(ILogger<GetActiveAdsForUserHandler> logger, IAdService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<AdResponse>> Handle(GetActiveAdsForUserQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Advertisement> ads = await _service.GetActiveAdsForUser(request, cancellationToken);
            _logger.LogInformation("Got {Advertisements} for user {UserId}", ads.Count, request.UserId);
            return _mapper.Map<List<AdResponse>>(ads);
        }
    }
}

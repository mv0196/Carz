using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Advertisement;
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
    public class CreateAdHandler : IRequestHandler<CreateAdCommand, AdResponse>
    {
        private readonly ILogger<CreateAdHandler> _logger;
        private readonly IAdService _service;
        private readonly IMapper _mapper;

        public CreateAdHandler(ILogger<CreateAdHandler> logger, IAdService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<AdResponse> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Advertisement ad = await _service.CreateAd(request, cancellationToken);
            if(ad == null)
            {
                _logger.LogInformation("Unable to create advertisement by {UserId}", request.UserId);
                return null;
            }
            _logger.LogInformation("Advertisement {AdvertisementId} created by {UserId}", ad.Id, request.UserId);
            return _mapper.Map<AdResponse>(ad);
        }
    }
}

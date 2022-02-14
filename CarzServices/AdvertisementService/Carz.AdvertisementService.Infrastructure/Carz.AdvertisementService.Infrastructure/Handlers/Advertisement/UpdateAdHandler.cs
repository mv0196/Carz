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
    class UpdateAdHandler : IRequestHandler<UpdateAdCommand, AdResponse>
    {
        private readonly ILogger<UpdateAdHandler> _logger;
        private readonly IAdService _service;
        private readonly IMapper _mapper;

        public UpdateAdHandler(ILogger<UpdateAdHandler> logger, IAdService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<AdResponse> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Advertisement ad = await _service.UpdateAd(request, cancellationToken);
            if (ad == null)
            {
                _logger.LogInformation("Unable to Update advertisement by {UserId}", request.UpdatedBy);
                return null;
            }
            _logger.LogInformation("Advertisement {AdvertisementId} updated by {UserId}", ad.Id, request.UpdatedBy);
            return _mapper.Map<AdResponse>(ad);
        }
    }
}

using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Advertisement;
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
    class EnableAdHandler : IRequestHandler<EnableAdCommand, bool>
    {
        private readonly ILogger<EnableAdHandler> _logger;
        private readonly IAdService _service;
        private readonly IMapper _mapper;

        public EnableAdHandler(ILogger<EnableAdHandler> logger, IAdService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<bool> Handle(EnableAdCommand request, CancellationToken cancellationToken)
        {
            bool res = await _service.EnableAd(request, cancellationToken);
            if (res)
            {
                _logger.LogInformation("Advertisement {AdvertisementId} enabled by {UserId}", request.Id, request.PerformedBy);
            }
            else
            {
                _logger.LogInformation("Unable to enable Advertisement {AdvertisementId} by {UserId}", request.Id, request.PerformedBy);
            }
            return res;
        }
    }
}

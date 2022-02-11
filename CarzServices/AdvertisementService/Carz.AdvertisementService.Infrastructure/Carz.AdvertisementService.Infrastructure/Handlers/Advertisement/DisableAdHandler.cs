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
    public class DisableAdHandler : IRequestHandler<DisableAdCommand,bool>
    {
        private readonly ILogger<DisableAdHandler> _logger;
        private readonly IAdService _service;
        private readonly IMapper _mapper;

        public DisableAdHandler(ILogger<DisableAdHandler> logger, IAdService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DisableAdCommand request, CancellationToken cancellationToken)
        {
            bool res = await _service.DisableAd(request, cancellationToken);
            if(res)
            {
                _logger.LogInformation("Advertisement {AdvertisementId} disabled by {UserId}", request.Id, request.AdminId);
            }
            else
            {
                _logger.LogInformation("Unable to disable Advertisement {AdvertisementId} by {UserId}", request.Id, request.AdminId);
            }
            return res;
        }
    }
}

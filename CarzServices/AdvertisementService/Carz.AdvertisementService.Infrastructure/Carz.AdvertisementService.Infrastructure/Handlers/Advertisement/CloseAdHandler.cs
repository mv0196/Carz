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
    public class CloseAdHandler : IRequestHandler<CloseAdCommand, bool>
    {
        private readonly ILogger<CloseAdHandler> _logger;
        private readonly IAdService _service;
        private readonly IMapper _mapper;

        public CloseAdHandler(ILogger<CloseAdHandler> logger, IAdService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CloseAdCommand request, CancellationToken cancellationToken)
        {
            bool res = await _service.CloseAd(request, cancellationToken);
            if (res)
            {
                _logger.LogInformation("Advertisement {AdvertisementId} closed by {UserId}", request.Id);
            }
            else
            {
                _logger.LogInformation("Unable to close Advertisement {AdvertisementId} by {UserId}", request.Id);
            }
            return res;
        }
    }
}

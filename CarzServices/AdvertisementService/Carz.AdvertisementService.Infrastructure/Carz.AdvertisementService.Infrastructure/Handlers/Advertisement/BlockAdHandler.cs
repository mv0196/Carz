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
    public class BlockAdHandler : IRequestHandler<BlockAdCommand, bool>
    {
        private readonly ILogger<BlockAdHandler> _logger;
        private readonly IAdService _service;
        private readonly IMapper _mapper;

        public BlockAdHandler(ILogger<BlockAdHandler> logger, IAdService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<bool> Handle(BlockAdCommand request, CancellationToken cancellationToken = default)
        {
            bool res = await _service.BlockAd(request, cancellationToken);
            if (res)
            {
                _logger.LogInformation("Advertisement {AdvertisementId} blocked by {UserId}", request.Id, request.AdminId);
            }
            else
            {
                _logger.LogInformation("Unable to block Advertisement {AdvertisementId} by {UserId}", request.Id, request.AdminId);
            }
            return res;
        }
    }
}

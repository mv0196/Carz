using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Bid;
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

namespace Carz.AdvertisementService.Infrastructure.Handlers.Bid
{
    class RemoveBidHandler : IRequestHandler<RemoveBidCommand, bool>
    {
        private readonly ILogger<RemoveBidHandler> _logger;
        private readonly IBidService _service;
        private readonly IMapper _mapper;

        public RemoveBidHandler(ILogger<RemoveBidHandler> logger, IBidService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RemoveBidCommand request, CancellationToken cancellationToken)
        {
            bool res = await _service.RemoveBid(request, cancellationToken);
            if (res == false)
            {
                _logger.LogInformation("Unable to remove bid for advertisement {Advertisement} by user {UserId}", request.AdvertisementId, request.UserId);
                return res;
            }
            _logger.LogInformation("Removed bid for advertisement {Advertisement} by user {UserId}", request.AdvertisementId, request.UserId);
            return res;
        }
    }
}

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
    public class PlaceBidHandler : IRequestHandler<PlaceBidCommand, BidResponse>
    {
        private readonly ILogger<PlaceBidHandler> _logger;
        private readonly IBidService _service;
        private readonly IMapper _mapper;

        public PlaceBidHandler(ILogger<PlaceBidHandler> logger, IBidService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<BidResponse> Handle(PlaceBidCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Bid bid = await _service.PlaceBid(request, cancellationToken);
            if(bid == null)
            {
                _logger.LogInformation("Unable to create bid for advertisement {Advertisement} by user {UserId}", request.AdvertisementId, request.UserId);
                return null;
            }
            _logger.LogInformation("Created bid for advertisement {Advertisement} by user {UserId}", request.AdvertisementId, request.UserId);
            return _mapper.Map<BidResponse>(bid);
        }
    }
}

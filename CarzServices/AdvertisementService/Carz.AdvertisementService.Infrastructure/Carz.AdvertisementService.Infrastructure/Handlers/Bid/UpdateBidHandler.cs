using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Bid;
using Carz.AdvertisementService.Domain.Responses;
using Carz.AdvertisementService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.Infrastructure.Handlers.Bid
{
    public class UpdateBidHandler : IRequestHandler<UpdateBidCommand, BidResponse>
    {
        private readonly ILogger<UpdateBidHandler> _logger;
        private readonly IBidService _service;
        private readonly IMapper _mapper;

        public UpdateBidHandler(ILogger<UpdateBidHandler> logger, IBidService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<BidResponse> Handle(UpdateBidCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Bid bid = await _service.UpdateBid(request, cancellationToken);
            if (bid == null)
            {
                _logger.LogInformation("Unable to update bid for advertisement {Advertisement} by user {UserId}", request.AdvertisementId, request.UserId);
                return null;
            }
            _logger.LogInformation("Updated bid for advertisement {Advertisement} by user {UserId}", request.AdvertisementId, request.UserId);
            return _mapper.Map<BidResponse>(bid);
        }
    }
}

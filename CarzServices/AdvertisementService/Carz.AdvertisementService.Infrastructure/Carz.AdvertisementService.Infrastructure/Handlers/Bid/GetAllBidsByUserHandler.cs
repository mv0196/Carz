﻿using AutoMapper;
using Carz.AdvertisementService.Domain.Queries.Bid;
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
    public class GetAllBidsByUserHandler : IRequestHandler<GetAllBidsByUserQuery, List<BidResponse>>
    {
        private readonly ILogger<GetAllBidsByUserHandler> _logger;
        private readonly IBidService _service;
        private readonly IMapper _mapper;

        public GetAllBidsByUserHandler(ILogger<GetAllBidsByUserHandler> logger, IBidService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<List<BidResponse>> Handle(GetAllBidsByUserQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Bid> bids = await _service.GetAllBidsByUser(request, cancellationToken);
            _logger.LogInformation("Got {Bids} bids for user {UserId}", bids.Count, request.UserId);
            return _mapper.Map<List<BidResponse>>(bids);
        }
    }
}

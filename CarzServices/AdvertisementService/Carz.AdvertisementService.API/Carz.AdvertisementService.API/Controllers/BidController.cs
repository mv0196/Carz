using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Bid;
using Carz.AdvertisementService.Domain.DTO.RequestDTO.Bid;
using Carz.AdvertisementService.Domain.Queries.Bid;
using Carz.AdvertisementService.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.AdvertisementService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly ILogger<BidController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BidController(ILogger<BidController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [NonAction]
        private Guid GetUserIdFromContext()
        {
            Guid userId = Guid.Empty;
            Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value, out userId);
            return userId;
        }

        [HttpGet("user/{AdvertisementId}")]
        public async Task<IActionResult> GetAllBidsByUser(GetAllBidsByUserQueryDTO request, CancellationToken cancellationToken)
        {
            GetAllBidsByUserQuery query = _mapper.Map<GetAllBidsByUserQuery>(request);
            query.UserId = GetUserIdFromContext();
            List<BidResponse> bids = await _mediator.Send(query, cancellationToken);
            return Ok(bids);
        }

        [HttpGet("won")]
        public async Task<IActionResult> GetWonBidsByUser(GetWonBidsByUserQueryDTO request, CancellationToken cancellationToken)
        {
            GetWonBidsByUserQuery query = _mapper.Map<GetWonBidsByUserQuery>(request);
            query.UserId = GetUserIdFromContext();
            List<BidResponse> bids = await _mediator.Send(query, cancellationToken);
            return Ok(bids);
        }

        [HttpPost("place")]
        public async Task<IActionResult> PlaceBid(PlaceBidCommandDTO request, CancellationToken cancellationToken)
        {
            PlaceBidCommand command = _mapper.Map<PlaceBidCommand>(request);
            command.UserId = GetUserIdFromContext();
            BidResponse bid = await _mediator.Send(command, cancellationToken);
            if (bid == null)
                return BadRequest();
            return Ok(bid);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBid(RemoveBidCommandDTO request, CancellationToken cancellationToken)
        {
            RemoveBidCommand command = _mapper.Map<RemoveBidCommand>(request);
            command.UserId = GetUserIdFromContext();
            bool bid = await _mediator.Send(command, cancellationToken);
            if (bid == false)
                return BadRequest();
            return Ok(bid);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateBid(UpdateBidCommandDTO request, CancellationToken cancellationToken)
        {
            UpdateBidCommand command = _mapper.Map<UpdateBidCommand>(request);
            command.UserId = GetUserIdFromContext();
            BidResponse bid = await _mediator.Send(command, cancellationToken);
            if (bid == null)
                return BadRequest();
            return Ok(bid);
        }


    }
}

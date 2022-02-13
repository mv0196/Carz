using AutoMapper;
using Carz.AdvertisementService.Domain.Commands.Advertisement;
using Carz.AdvertisementService.Domain.DTO.RequestDTO;
using Carz.AdvertisementService.Domain.Entities;
using Carz.AdvertisementService.Domain.Queries.Advertisement;
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
    public class AdvertisementController : ControllerBase
    {
        private readonly ILogger<AdvertisementController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AdvertisementController(ILogger<AdvertisementController> logger, IMediator mediator, IMapper mapper)
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

        [HttpGet("block/{Id}")]
        public async Task<IActionResult> BlockAd(BlockAdCommandDTO request, CancellationToken cancellationToken = default)
        {
            Guid userId = GetUserIdFromContext();
            BlockAdCommand command = new BlockAdCommand { Id = request.Id, PerformedBy = userId };
            bool res = await _mediator.Send(command, cancellationToken);
            if (!res)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("close/")]
        public async Task<IActionResult> CloseAd(CloseAdCommandDTO request, CancellationToken cancellationToken = default)
        {
            Guid userId = GetUserIdFromContext();
            CloseAdCommand command = new CloseAdCommand { Id = request.Id, ClosedBy = userId };
            bool res = await _mediator.Send(command, cancellationToken);
            if (!res)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateAdCommandDTO request, CancellationToken cancellationToken)
        {
            Guid userId = GetUserIdFromContext();
            CreateAdCommand command = _mapper.Map<CreateAdCommand>(request);
            command.UserId = userId;

            AdResponse res = await _mediator.Send(command, cancellationToken);
            if (res == null)
            {
                return BadRequest();
            }
            return Created($"{Request.Path}/{res.Id}", res);
        }

        [HttpPost("disable/")]
        public async Task<IActionResult> DisableAd(DisableAdCommandDTO request, CancellationToken cancellationToken = default)
        {
            Guid userId = GetUserIdFromContext();
            DisableAdCommand command = _mapper.Map<DisableAdCommand>(request);
            command.DisabledBy = userId;
            bool res = await _mediator.Send(command, cancellationToken);
            if (!res)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("enable/")]
        public async Task<IActionResult> EnableAd(EnableAdCommandDTO request, CancellationToken cancellationToken = default)
        {
            Guid userId = GetUserIdFromContext();
            EnableAdCommand command = _mapper.Map<EnableAdCommand>(request);
            command.PerformedBy = userId;
            bool res = await _mediator.Send(command, cancellationToken);
            if (!res)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet("active/user/{UserId}")]
        public async Task<IActionResult> GetActiveAdsForUser(GetActiveAdsForUserQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }


        [HttpGet("active")]
        public async Task<IActionResult> GetActiveAds(GetActiveAdsQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }

        [HttpGet("user/{UserId}")]
        public async Task<IActionResult> GetAdsForUser(GetAdsForUserQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAds(GetAllAdsQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }

        [HttpGet("blocked/user/{UserId}")]
        public async Task<IActionResult> GetBlockedAdsForUser(GetBlockedAdsForUserQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }


        [HttpGet("blocked")]
        public async Task<IActionResult> GetBlockedAds(GetBlockedAdsQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }

        [HttpGet("closed/user/{UserId}")]
        public async Task<IActionResult> GetClosedAdsForUser(GetClosedAdsForUserQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }


        [HttpGet("closed")]
        public async Task<IActionResult> GetClosedAds(GetClosedAdsQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }

        [HttpGet("disabled/user/{UserId}")]
        public async Task<IActionResult> GetDisabledAdsForUser(GetDisabledAdsForUserQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }


        [HttpGet("disabled")]
        public async Task<IActionResult> GetDisabledAds(GetDisabledAdsQuery query, CancellationToken cancellationToken)
        {
            List<AdResponse> ads = await _mediator.Send(query, cancellationToken);
            return Ok(ads);
        }

    }
}

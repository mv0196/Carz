using AutoMapper;
using Carz.UserService.Domain.Entities;
using Carz.UserService.Domain.Queries;
using Carz.UserService.Domain.Responses;
using Carz.UserService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.UserService.Infrastructure.Handlers
{
    public class GeProfileByIdentityIdHandler : IRequestHandler<GetProfileByIdentityIdQuery, ProfileResponse>
    {
        private readonly ILogger<GeProfileByIdentityIdHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public GeProfileByIdentityIdHandler(ILogger<GeProfileByIdentityIdHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<ProfileResponse> Handle(GetProfileByIdentityIdQuery request, CancellationToken cancellationToken = default)
        {
            User user = await _service.GetProfileByIdentityId(request.IdentityId, cancellationToken);
            if (user != null)
            {
                _logger.LogInformation("User with Identity Id: {IdentityId} fetched successfully", request.IdentityId);
                return _mapper.Map<ProfileResponse>(user);
            }
            _logger.LogInformation("User with Identity Id: {IdentityId} not found", request.IdentityId);
            return null;
        }
    }
}

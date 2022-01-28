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
    public class GeProfileByIdHandler : IRequestHandler<GetProfileByIdQuery, ProfileResponse>
    {
        private readonly ILogger<GeProfileByIdHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public GeProfileByIdHandler(ILogger<GeProfileByIdHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<ProfileResponse> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _service.GetProfileById(request.Id, cancellationToken);
            if (user != null)
            {
                _logger.LogInformation("User with Identity Id: {IdentityId} fetched successfully", request.Id);
                return _mapper.Map<ProfileResponse>(user);
            }
            _logger.LogInformation("User with Identity Id: {IdentityId} not found", request.Id);
            return null;
        }
    }
}

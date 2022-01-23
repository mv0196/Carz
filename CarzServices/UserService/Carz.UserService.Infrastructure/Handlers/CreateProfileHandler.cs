using Carz.UserService.Domain.Commands;
using Carz.UserService.Domain.Responses;
using Microsoft.Extensions.Logging;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Carz.UserService.Domain.Services;
using AutoMapper;
using Carz.UserService.Domain.Entities;

namespace Carz.UserService.Infrastructure.Handlers
{
    public class CreateProfileHandler : IRequestHandler<CreateProfileCommand, ProfileResponse>
    {
        private readonly ILogger<CreateProfileHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public CreateProfileHandler(ILogger<CreateProfileHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<ProfileResponse> Handle(CreateProfileCommand request, CancellationToken cancellationToken = default)
        {
            User user = await _service.CreateProfile(_mapper.Map<User>(request), cancellationToken);
            if (user != null)
            {
                _logger.LogInformation("User with user id {UserId} created successfully",user.Id);
                return _mapper.Map<ProfileResponse>(user);
            }
            _logger.LogInformation("Unable to create user with identity id {IdentityId}", user.IdentityId);
            return null;
        }
    }
}

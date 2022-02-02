using AutoMapper;
using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Responses.User;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserComand, UserResponse>
    {
        private readonly ILogger<CreateUserHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public CreateUserHandler(ILogger<CreateUserHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<UserResponse> Handle(CreateUserComand request, CancellationToken cancellationToken)
        {
            IdentityUser user = await _service.CreateUser(request, cancellationToken);
            if (user == null)
            {
                _logger.LogInformation("Unable to create user with email : {email}", request.Email);
                return null;
            }
            else
            {
                _logger.LogInformation("Created user with email : {email}", request.Email);
                return _mapper.Map<UserResponse>(user);
            }
        }
    }
}

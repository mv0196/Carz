using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class DisableUserHandler : IRequestHandler<DisableUserCommand, bool>
    {
        private readonly ILogger<DisableUserHandler> _logger;
        private readonly IUserService _service;

        public DisableUserHandler(ILogger<DisableUserHandler> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<bool> Handle(DisableUserCommand request, CancellationToken cancellationToken = default)
        {
            bool res = await _service.DisableUser(request, cancellationToken);
            if (res == false)
                _logger.LogInformation($"unable to disable user : {request.Id} by {request.AdminId}");
            else
                _logger.LogInformation($"User : {request.Id} disabled by {request.AdminId}");

            return res;
        }
    }
}

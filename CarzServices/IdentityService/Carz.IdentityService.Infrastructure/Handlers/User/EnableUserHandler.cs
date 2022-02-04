using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class EnableUserHandler : IRequestHandler<EnableUserCommand, bool>
    {
        private readonly ILogger<EnableUserHandler> _logger;
        private readonly IUserService _service;

        public EnableUserHandler(ILogger<EnableUserHandler> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<bool> Handle(EnableUserCommand request, CancellationToken cancellationToken = default)
        {
            bool res = await _service.EnableUser(request, cancellationToken);
            if (res == false)
                _logger.LogInformation($"unable to Enable user : {request.Id} by {request.AdminId}");
            else
                _logger.LogInformation($"User : {request.Id} Enabled by {request.AdminId}");

            return res;
        }
    }
}

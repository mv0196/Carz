using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class BlockUserHandler : IRequestHandler<BlockUserCommand, bool>
    {
        private readonly ILogger<BlockUserHandler> _logger;
        private readonly IUserService _service;

        public BlockUserHandler(ILogger<BlockUserHandler> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<bool> Handle(BlockUserCommand request, CancellationToken cancellationToken = default)
        {
            bool res = await _service.BlockUser(request, cancellationToken);
            if (res == false)
                _logger.LogInformation($"unable to block user : {request.Id} by {request.AdminId}");
            else
                _logger.LogInformation($"User : {request.Id} blocked by {request.AdminId}");

            return res;
        }
    }
}

using AutoMapper;
using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class AssignRoleToUserHandler : IRequestHandler<AssignRoleToUserCommand, bool>
    {
        private readonly ILogger<AssignRoleToUserHandler> _logger;
        private readonly IUserService _service;

        public AssignRoleToUserHandler(ILogger<AssignRoleToUserHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<bool> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken = default)
        {
            bool res = await _service.AssignRoleToUser(request, cancellationToken);
            if (res == false)
                _logger.LogInformation($"unable to assign role : {request.RoleId} to user : {request.Id} by {request.AdminId}");
            else
                _logger.LogInformation($"Role : {request.RoleId} assigned to user : {request.Id} by {request.AdminId}");

            return res;
        }
    }
}

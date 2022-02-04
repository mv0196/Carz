using AutoMapper;
using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class RevokeRoleFromUserHandler : IRequestHandler<RevokeRoleFromUserCommand, bool>
    {
        private readonly ILogger<RevokeRoleFromUserHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public RevokeRoleFromUserHandler(ILogger<RevokeRoleFromUserHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RevokeRoleFromUserCommand request, CancellationToken cancellationToken = default)
        {
            bool res = await _service.RevokeRoleFromUser(request, cancellationToken);
            if (res == false)
                _logger.LogInformation($"unable to revoke role : {request.RoleId} from user : {request.Id} by {request.AdminId}");
            else
                _logger.LogInformation($"Role : {request.RoleId} revoked from user : {request.Id} by {request.AdminId}");

            return res;
        }
    }
}

using AutoMapper;
using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.Role
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly ILogger<DeleteRoleHandler> _logger;
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

        public DeleteRoleHandler(ILogger<DeleteRoleHandler> logger, IRoleService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken = default)
        {
            bool res = await _service.DeleteRole(request, cancellationToken);
            if (res == false)
            {
                _logger.LogInformation("Unable to delete role with Id: {RoleId} by User: {IdentityId}", request.Id, request.DeletedBy);
                return res;
            }
            _logger.LogInformation("Role with Id: {RoleId} deleted by User: {IdentityId}", request.Id, request.DeletedBy);
            return res;
        }
    }
}

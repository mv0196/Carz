using AutoMapper;
using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.Responses.Role;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.Role
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, RoleResponse>
    {
        private readonly ILogger<UpdateRoleHandler> _logger;
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

        public UpdateRoleHandler(ILogger<UpdateRoleHandler> logger, IRoleService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<RoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken = default)
        {
            Domain.Entities.Role role = await _service.UpdateRole(request, cancellationToken);
            if(role == null)
            {
                _logger.LogInformation("Unable to update Role with Id: {RoleId} by User: {IdentityId}", request.Id, request.UpdatedBy);
                return null;
            }
            _logger.LogInformation("Updated Role with Id: {RoleId} to Name: {RoleName} by User: {IdentityId}", request.Id, request.Name, request.UpdatedBy);
            return _mapper.Map<RoleResponse>(role);
        }
    }
}

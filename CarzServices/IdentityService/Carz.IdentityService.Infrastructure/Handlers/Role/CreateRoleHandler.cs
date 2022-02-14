using AutoMapper;
using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.Responses.Role;
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
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, RoleResponse>
    {
        private readonly ILogger<CreateRoleHandler> _logger;
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

        public CreateRoleHandler(ILogger<CreateRoleHandler> logger, IRoleService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<RoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken = default)
        {
            Domain.Entities.Role role = await _service.CreateRole(request, cancellationToken);
            if(role == null)
            {
                _logger.LogInformation("Unable to create role with Name: {Name} by User: {IdentityId}", request.Name, request.CreatedBy);
                return null;
            }
            _logger.LogInformation("Role with Name: {Name} created by User: {IdentityId}", request.Name, request.CreatedBy);
            return _mapper.Map<RoleResponse>(role);
            
        }
    }
}

using AutoMapper;
using Carz.IdentityService.Domain.Queries.Role;
using Carz.IdentityService.Domain.Responses.Role;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.Role
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, List<RoleResponse>>
    {
        private readonly ILogger<GetAllRolesHandler> _logger;
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

        public GetAllRolesHandler(ILogger<GetAllRolesHandler> logger, IRoleService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<List<RoleResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken = default)
        {
            List<Domain.Entities.Role> roles = await _service.GetAllRoles(request, cancellationToken);
            return _mapper.Map<List<RoleResponse>>(roles);
        }
    }
}

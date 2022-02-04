using AutoMapper;
using Carz.IdentityService.Domain.Queries.User;
using Carz.IdentityService.Domain.Responses.Role;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class GetUserRolesHandler : IRequestHandler<GetUserRolesQuery, List<RoleResponse>>
    {
        private readonly ILogger<GetUserRolesHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public GetUserRolesHandler(ILogger<GetUserRolesHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<RoleResponse>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken = default)
        {
            List<Domain.Entities.Role> roles = await _service.GetUserRoles(request, cancellationToken);
            if(roles == null)
            {
                _logger.LogInformation("User with id : {IdentityId} not found", request.Id);
            }
            else
            {
                _logger.LogInformation("Got roles for user with id : {IdentityId}", request.Id);
            }

            return _mapper.Map<List<RoleResponse>>(roles);
        }
    }
}

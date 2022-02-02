using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
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
        public Task<RoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using Carz.IdentityService.Domain.Commands.Role;
using MediatR;
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
        public Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

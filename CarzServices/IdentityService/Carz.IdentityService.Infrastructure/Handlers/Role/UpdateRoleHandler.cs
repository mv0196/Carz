using Carz.IdentityService.Domain.Commands.Role;
using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.Role
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, RoleResponse>
    {
        public Task<RoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

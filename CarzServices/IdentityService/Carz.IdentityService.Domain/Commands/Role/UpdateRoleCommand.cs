using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class UpdateRoleCommand : IRequest<RoleResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

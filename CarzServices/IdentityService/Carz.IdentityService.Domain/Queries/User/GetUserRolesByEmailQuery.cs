using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Queries.User
{
    public class GetUserRolesByEmailQuery : IRequest<List<RoleResponse>>
    {
        public string Email { get; set; }
    }
}

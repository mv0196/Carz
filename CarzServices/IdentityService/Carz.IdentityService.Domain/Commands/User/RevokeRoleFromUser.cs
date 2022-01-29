using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class RevokeRoleFromUser : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
    }
}

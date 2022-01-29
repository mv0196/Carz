using Carz.IdentityService.Domain.Responses.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Commands.Role
{
    public class CreateRole : IRequest<UserResponse>
    {
        public string Name { get; set; }
    }
}

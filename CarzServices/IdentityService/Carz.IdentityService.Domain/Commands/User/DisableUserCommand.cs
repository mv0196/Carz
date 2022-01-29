using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Commands.User
{
    public class DisableUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

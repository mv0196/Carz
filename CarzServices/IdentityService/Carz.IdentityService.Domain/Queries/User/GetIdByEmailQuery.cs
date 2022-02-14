using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Queries.User
{
    public class GetIdByEmailQuery : IRequest<Guid>
    {
        public string Email { get; set; }
    }
}

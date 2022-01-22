using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.UserService.Domain.Commands.Role
{
    public class UpdateRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

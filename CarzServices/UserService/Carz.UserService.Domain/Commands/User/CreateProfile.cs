using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.UserService.Domain.Commands.User
{
    public class CreateProfile
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Aadhaar { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNum { get; set; }
        public string Address { get; set; }
        public bool IsEnabled { get; set; }
    }
}

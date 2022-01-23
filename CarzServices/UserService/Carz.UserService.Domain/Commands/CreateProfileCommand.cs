using Carz.UserService.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carz.UserService.Domain.Commands
{
    public class CreateProfileCommand : IRequest<ProfileResponse>
    {
        public string Name { get; set; }
        public string Aadhaar { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNum { get; set; }
        public string Address { get; set; }
    }
}

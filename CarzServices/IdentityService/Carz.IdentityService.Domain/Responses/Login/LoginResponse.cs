using System;
using System.Collections.Generic;

namespace Carz.IdentityService.Domain.Responses.Login
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public List<Carz.IdentityService.Domain.Entities.Role> Roles{ get; set; }
        public string Token { get; set; }
    }
}

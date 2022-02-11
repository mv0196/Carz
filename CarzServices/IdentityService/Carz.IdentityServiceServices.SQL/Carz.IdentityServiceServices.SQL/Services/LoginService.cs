using Carz.Common.Configuration;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.Login;
using Carz.IdentityService.Domain.Services;
using Carz.IdentityService.Services.SQL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Services.SQL.Services
{
    public class LoginService : ILoginService
    {
        private readonly IdentityUserDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginService(IdentityUserDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string GenerateToken(IdentityUser user)
        {
            var roles = _context.IdentityUserRoles.Where(ur => ur.IdentityUserId == user.Id).Select(r => r.Role.Name);
            string rolesString = "";
            if (roles.Count() > 0)
            {
                rolesString = string.Join(",", roles);
            }

            var claims = new[]
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString()),
                new Claim("Roles", rolesString)
            };

            var jwtConfiguration = new JwtConfiguration();
            _configuration.Bind(nameof(jwtConfiguration), jwtConfiguration);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "IdentityService",
                audience: "UserService",
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwtConfiguration.ExpiryTimeInMinutes)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> Login(LoginQuery query, CancellationToken cancellationToken = default)
        {
            string passwordHash = query.Password;// will come from service 
            IdentityUser user = await _context.IdentityUsers.FirstOrDefaultAsync(u => u.Email == query.Email && u.PasswordHash == passwordHash);

            if (user == null)
                return null;

            return GenerateToken(user);
        }
    }
}

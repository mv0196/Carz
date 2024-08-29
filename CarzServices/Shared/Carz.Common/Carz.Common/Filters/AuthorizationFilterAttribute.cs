using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.Common.Filters
{
    public class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly JwtSecurityTokenHandler handler;
        private List<string> AllowedRoles = new List<string>();

        public AuthorizationFilterAttribute()
        {
            AllowedRoles = new List<string>();
            this.handler = new JwtSecurityTokenHandler();
        }

        public AuthorizationFilterAttribute(string roles)
        {
            AllowedRoles = roles.Split(",").ToList();
            this.handler = new JwtSecurityTokenHandler();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authHeader = context.HttpContext.Request.Headers.Authorization;

            // No token provided
            if (authHeader.Any() == false)
            {
                context.Result = new UnauthorizedObjectResult("Provide authorization token to access the API");
            }

            var authHeaderStr = authHeader.ToString();
            if (authHeaderStr == null)
            {
                context.Result = new UnauthorizedObjectResult("Provide authorization token to access the API");
            }

            var token = authHeaderStr.Split()[1];

            string tokenRolesStr = "";
            string email = "";
            Guid Id = Guid.Empty;

            var decodedToken = handler.ReadJwtToken(token);

            tokenRolesStr = decodedToken.Claims.FirstOrDefault(c => c.Type == "Roles").Value;
            email = decodedToken.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            Guid.TryParse(decodedToken.Claims.FirstOrDefault(c => c.Type == "Id").Value, out Id);

            List<string> roles = tokenRolesStr.Split(",").ToList();

            if (roles.Intersect(AllowedRoles).Count() == 0)
            {
                context.Result = new UnauthorizedObjectResult("Provide authorization token to access the API");
            }

            //means allowed, so continue
            //string body = await context.HttpContext.Request.Content.ReadAsStringAsync();
            context.HttpContext.Request.Headers.Append("PerformedBy", Id.ToString());
        }
    }
}

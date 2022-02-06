using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Carz.Common.Filters
{
    public class AuthorizationFilterAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
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

        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage msg = new HttpResponseMessage();

            var authHeader = actionContext.Request.Headers.Authorization;

            // No token provided
            if (authHeader == null)
            {
                msg.StatusCode = HttpStatusCode.Unauthorized;
                msg.Content = new StringContent("Provide authorization token to access the API");
                actionContext.Response = msg;
            }

            var authHeaderStr = authHeader.ToString();
            if (authHeaderStr == null)
            {
                msg.StatusCode = HttpStatusCode.Unauthorized;
                msg.Content = new StringContent("Provide authorization token to access the API");
                actionContext.Response = msg;
            }

            var token = authHeaderStr.Split()[1];

            string tokenRolesStr = "";
            string email = "";
            Guid Id = Guid.Empty;

            var decodedToken = handler.ReadJwtToken(token);

            tokenRolesStr = decodedToken.Claims.FirstOrDefault(c => c.Type == "roles").Value;
            email = decodedToken.Claims.FirstOrDefault(c => c.Type == "email").Value;
            Guid.TryParse(decodedToken.Claims.FirstOrDefault(c => c.Type == "Id").Value, out Id);

            List<string> roles = tokenRolesStr.Split(",").ToList();

            if (roles.Intersect(AllowedRoles).Count() == 0)
            {
                msg.StatusCode = HttpStatusCode.Unauthorized;
                msg.Content = new StringContent("Provide authorization token to access the API");
                actionContext.Response = msg;
            }

            //means allowed, so continue
            //string body = await actionContext.Request.Content.ReadAsStringAsync();
            actionContext.Request.Headers.Add("AdminId", Id.ToString());
            await base.OnAuthorizationAsync(actionContext, cancellationToken);
        }
    }
}

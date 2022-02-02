using Carz.IdentityService.Domain.Responses.Role;
using MediatR;
using System;
using System.Collections.Generic;

namespace Carz.IdentityService.Domain.Queries.User
{
    public class GetUserRolesQuery : IRequest<List<RoleResponse>>
    {
        public Guid Id { get; set; }
    }
}

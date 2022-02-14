using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.User;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Services
{
    public interface IUserService
    {
        // Commands
        Task<IdentityUser> CreateUser(CreateUserComand command, CancellationToken cancellationToken = default);
        Task<IdentityUser> UpdateUser(UpdateUserCommand command, CancellationToken cancellationToken = default);
        Task<bool> BlockUser(BlockUserCommand command, CancellationToken cancellationToken = default);
        Task<bool> EnableUser(EnableUserCommand command, CancellationToken cancellationToken = default);
        Task<bool> DisableUser(DisableUserCommand command, CancellationToken cancellationToken = default);
        Task<bool> ForgotPassword(ForgotPasswordCommand command, CancellationToken cancellationToken = default);
        Task<bool> AssignRoleToUser(AssignRoleToUserCommand command, CancellationToken cancellationToken = default);
        Task<bool> RevokeRoleFromUser(RevokeRoleFromUserCommand command, CancellationToken cancellationToken = default);

        // Queries
        Task ForgotPassword(ForgotPasswordQuery query, CancellationToken cancellationToken = default);
        Task<IdentityUser> GetUserById(GetUserByIdQuery query, CancellationToken cancellationToken = default);
        Task<List<Role>> GetUserRoles(GetUserRolesQuery query, CancellationToken cancellationToken = default);
        Task<List<Role>> GetUserRolesByEmail(GetUserRolesByEmailQuery query, CancellationToken cancellationToken = default);
        Task<Guid> GetIdByEmail(GetIdByEmailQuery query, CancellationToken cancellationToken = default);
    }
}

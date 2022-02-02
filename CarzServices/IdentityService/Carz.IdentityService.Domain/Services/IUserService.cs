using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.User;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Domain.Services
{
    public interface IUserService
    {
        // Commands
        Task<IdentityUser> CreateUser(CreateUserComand command, CancellationToken cancellationToken);
        Task<IdentityUser> UpdateUser(UpdateUserCommand command, CancellationToken cancellationToken);
        Task<bool> BlockUser(BlockUserCommand command, CancellationToken cancellationToken);
        Task<bool> EnableUser(EnableUserCommand command, CancellationToken cancellationToken);
        Task<bool> DisableUser(DisableUserCommand command, CancellationToken cancellationToken);
        Task<bool> ForgotPassword(ForgotPasswordCommand command, CancellationToken cancellationToken);
        Task<bool> AssignRoleToUser(AssignRoleToUserCommand command, CancellationToken cancellationToken);
        Task<bool> RevokeRoleFromUser(RevokeRoleFromUserCommand command, CancellationToken cancellationToken);

        // Queries
        Task ForgotPassword(ForgotPasswordQuery query, CancellationToken cancellationToken);
        Task<IdentityUser> GetUserById(GetUserByIdQuery query, CancellationToken cancellationToken);
        Task<List<Role>> GetUserRoles(GetUserRolesQuery query, CancellationToken cancellationToken);
    }
}

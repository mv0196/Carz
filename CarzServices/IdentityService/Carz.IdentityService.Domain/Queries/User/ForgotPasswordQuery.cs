using MediatR;
using System;

namespace Carz.IdentityService.Domain.Queries.User
{
    /// <summary>
    /// It will just send mail to email to update password
    /// </summary>
    public class ForgotPasswordQuery : IRequest<bool>
    {
        public string Email { get; set; }
    }
}

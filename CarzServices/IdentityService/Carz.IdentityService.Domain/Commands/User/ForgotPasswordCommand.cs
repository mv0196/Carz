﻿using MediatR;
using System;

namespace Carz.IdentityService.Domain.Commands.User
{
    /// <summary>
    /// It will update the new password
    /// </summary>
    public class ForgotPasswordCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

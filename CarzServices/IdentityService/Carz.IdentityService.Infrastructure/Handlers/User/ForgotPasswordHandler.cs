using AutoMapper;
using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Queries.User;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordQuery, bool>, IRequestHandler<ForgotPasswordCommand, bool>
    {
        private readonly ILogger<ForgotPasswordHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public ForgotPasswordHandler(ILogger<ForgotPasswordHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        // Update password
        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken = default)
        {
            bool res = await _service.ForgotPassword(request, cancellationToken);
            if (res == false)
                _logger.LogInformation("Unable to change password for user : {email}", request.Email);
            else
                _logger.LogInformation("Changed password for user : {email}", request.Email);

            return res;
        }

        // send email
        public async Task<bool> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken = default)
        {
            return true;
        }
    }
}

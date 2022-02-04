using AutoMapper;
using Carz.IdentityService.Domain.Queries.Login;
using Carz.IdentityService.Domain.Queries.User;
using Carz.IdentityService.Domain.Responses.Login;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly ILogger<LoginQueryHandler> _logger;
        private readonly ILoginService _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginQueryHandler(ILogger<LoginQueryHandler> logger, ILoginService service, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken = default)
        {
            string token = await _service.Login(request, cancellationToken);
            if (token == null)
            {
                _logger.LogInformation("{Email} tried login, inavlid credentials", request.Email);
                return null;
            }
            _logger.LogInformation("{Email} logged in successfully", request.Email);
            List<Domain.Entities.Role> roles = await _userService.GetUserRolesByEmail(new GetUserRolesByEmailQuery
            {
                Email = request.Email
            }, cancellationToken);

            Guid id = await _userService.GetIdByEmail(new GetIdByEmailQuery
            {
                Email = request.Email
            }, cancellationToken);

            return new LoginResponse
            {
                Id = id,
                Email = request.Email,
                Roles = roles,
                Token = token,
            };
        }
    }
}

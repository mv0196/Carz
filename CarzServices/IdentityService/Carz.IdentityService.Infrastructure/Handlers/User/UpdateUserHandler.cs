using AutoMapper;
using Carz.IdentityService.Domain.Commands.User;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Responses.User;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly ILogger<UpdateUserHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UpdateUserHandler(ILogger<UpdateUserHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            IdentityUser user = await _service.UpdateUser(request, cancellationToken);
            if (user == null)
            {
                _logger.LogInformation("Unable to update user with Id : {IdentityId}", request.Id);
                return null;
            }
            else
            {
                _logger.LogInformation("Updated user with Id : {IdentityId}", request.Id);
                return _mapper.Map<UserResponse>(user);
            }
        }
    }
}

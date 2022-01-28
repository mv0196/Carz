using AutoMapper;
using Carz.UserService.Domain.Commands;
using Carz.UserService.Domain.Entities;
using Carz.UserService.Domain.Responses;
using Carz.UserService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.UserService.Infrastructure.Handlers
{
    public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand, ProfileResponse>
    {
        private readonly ILogger<UpdateProfileHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UpdateProfileHandler(ILogger<UpdateProfileHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }
        public async Task<ProfileResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            User updatedUser = _mapper.Map<User>(request);
            User user = await _service.UpdateProfile(request.IdentityId, updatedUser, cancellationToken);
            if (user == null)
            {
                _logger.LogInformation("User with Identity Id: {IdentityId} updated successfully", request.IdentityId);
                return _mapper.Map<ProfileResponse>(user);
            }
            _logger.LogInformation("User with Identity Id: {IdentityId} not found", request.IdentityId);
            return null;
        }
    }
}

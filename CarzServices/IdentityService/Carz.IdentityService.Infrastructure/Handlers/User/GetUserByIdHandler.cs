using AutoMapper;
using Carz.IdentityService.Domain.Entities;
using Carz.IdentityService.Domain.Queries.User;
using Carz.IdentityService.Domain.Responses.User;
using Carz.IdentityService.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carz.IdentityService.Infrastructure.Handlers.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly ILogger<GetUserByIdHandler> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(ILogger<GetUserByIdHandler> logger, IUserService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            IdentityUser user = await _service.GetUserById(request, cancellationToken);
            if(user == null)
            {
                _logger.LogInformation("User with Identity Id : {IdentityId} not found", request.Id);
                return null;
            }
            else
            {
                _logger.LogInformation("User with Identity Id : {IdentityId} found", request.Id);
                return _mapper.Map<UserResponse>(user);
            }
        }
    }
}

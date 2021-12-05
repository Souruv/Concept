using CF.ProjectService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces;
using AutoMapper;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using AutoMapper.QueryableExtensions;

namespace CF.ProjectService.Application.Features.UserFeatures.Queries
{
    public class GetAuthUserByEmailQuery : IRequest<AuthUserDto>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public class GetAuthUserByEmailQueryHandler : IRequestHandler<GetAuthUserByEmailQuery, AuthUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IAuthService _authService;
            public GetAuthUserByEmailQueryHandler(IAuthService authService, IMapper mapper)
            {
                _authService = authService;
                _mapper = mapper;
            }
            public async Task<AuthUserDto> Handle(GetAuthUserByEmailQuery query, CancellationToken cancellationToken)
            {
                return await _authService.GetDetailByEmail(query.Email, query.Token);
            }
        }
    }
}

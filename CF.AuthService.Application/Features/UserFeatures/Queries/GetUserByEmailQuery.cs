
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

using AutoMapper.QueryableExtensions;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CF.AuthService.Application.Features.UserFeatures.Queries
{
    public class GetUserByEmailQuery : IRequest<AppUserDto>
    {
        public string Email { get; set; }
        public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, AppUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetUserByEmailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<AppUserDto> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.UserRepository.GetSingleAsync(a => !a.IsDeleted && a.Email == query.Email
                ,source => source.Include(x => x.Role)
                 .Include(x => x.FelStage)
                 );//.ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefault();
                if (user == null) return null;
                
                var result=_mapper.Map<AppUser, AppUserDto>(user); 
                return result;
            }
        }
    }
}

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
    public class GetUserByIdQuery : IRequest<AppUserDto>
    {
        public Guid Id { get; set; }
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, AppUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<AppUserDto> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.UserRepository.GetSingleAsync(a => a.Id == query.Id);//.ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefault();
                if (user == null) return null;
                
                return _mapper.Map<AppUser, AppUserDto>(user);
            }
        }
    }
}

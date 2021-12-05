using CF.ProjectService.Application.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CF.ProjectService.Application.Features.UserFeatures.Dto;

namespace CF.ProjectService.Application.Features.UserFeatures.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<AppUserDto>>
    {

        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<AppUserDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IEnumerable<AppUserDto>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                var userList =  _unitOfWork.UserRepository.Filter(x=>!x.IsDeleted);
                if (userList == null)
                {
                    return null;
                }
                var list = await userList.ToListAsync();
                return await userList.ProjectTo<AppUserDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}

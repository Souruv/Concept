
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using CF.AuthService.Application.Features.UserFeatures.Dto;
using CF.AuthService.Application.Common.Interfaces;

namespace CF.AuthService.Application.Features.UserFeatures.Queries
{
    public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
    {

        public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery query, CancellationToken cancellationToken)
            {
                var roleList =  _unitOfWork.RoleRepository.Filter(x=>!x.IsDeleted).OrderBy(x=>x.SortOrder);
                if (roleList == null)
                {
                    return null;
                }
                var list = await roleList.ToListAsync();
                return await roleList.ProjectTo<RoleDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}

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
using System.Linq;
using CF.ProjectService.Application.Common.Bases;
using CF.ProjectService.Application.Common.Mappings;
using System.Linq.Dynamic.Core;

namespace CF.ProjectService.Application.Features.UserFeatures.Queries
{
    public class GetFilteredUsersQuery : BasePaginationQuery<AppUserDto>
    {
        public int? Role { get; set; } = 0;
        public string? SearchText { get; set; } = string.Empty;
       
        public class GetAllUsersQueryHandler : IRequestHandler<GetFilteredUsersQuery, PaginatedList<AppUserDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<PaginatedList<AppUserDto>> Handle(GetFilteredUsersQuery query, CancellationToken cancellationToken)
            {
                var userList = _unitOfWork.UserRepository.Filter(x => !x.IsDeleted);
                if (query.Role != 0) userList = userList.Where(x => x.Role == query.Role);
                if (userList == null)
                {
                    return null;
                }
                //return await userList.PaginatedListAsync(query.PageNumber, query.PageSize);
                //var list = await userList.ToListAsync();
                //return await userList.ProjectTo<AppUserDto>(_mapper.ConfigurationProvider).ToListAsync();

                if ((query.Role ?? 0) > 0)
                {
                    userList = userList.Where(x => x.Role==query.Role);
                }

                if (!string.IsNullOrEmpty(query.SearchText))
                {
                    userList = userList.Where(x => x.Name.Contains(query.SearchText) || x.Email.Contains(query.SearchText));
                }

                if (!string.IsNullOrEmpty(query.SortColumn))
                {
                    userList = userList.OrderBy(query.SortColumn + " " + query.SortDirection);
                }

                return await userList
                .ProjectTo<AppUserDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(query.PageIndex, query.PageSize);
            }
        }
    }
}

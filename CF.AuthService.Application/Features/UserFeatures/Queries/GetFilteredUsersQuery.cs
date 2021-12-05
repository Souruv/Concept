
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using System.Linq.Dynamic.Core;
using CF.AuthService.Application.Common.Bases;
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Common.Mappings;

namespace CF.AuthService.Application.Features.UserFeatures.Queries
{
    public class GetFilteredUsersQuery : BasePaginationQuery<AppUserDto>
    {
        public bool? IsAdmin { get; set; }
        public string? SearchText { get; set; } = string.Empty;
        public string? DepartmentName { get; set; }
        public Guid? RoleId { get; set; }
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
                var userList = _unitOfWork.UserRepository.Filter(x => !x.IsDeleted
                && x.Id != new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC")
                , source => source.Include(x => x.Role)
                 .Include(x => x.FelStage)
                );
                if (query.IsAdmin != null) userList = userList.Where(x => x.IsAdmin == query.IsAdmin);
                if (userList == null)
                {
                    return null;
                }

                if (!String.IsNullOrWhiteSpace(query.DepartmentName)) userList = userList.Where(x => x.DepartmentName == query.DepartmentName);
                if (query.RoleId != null) userList = userList.Where(x => x.RoleId == query.RoleId);

                //return await userList.PaginatedListAsync(query.PageNumber, query.PageSize);
                //var list = await userList.ToListAsync();
                //return await userList.ProjectTo<AppUserDto>(_mapper.ConfigurationProvider).ToListAsync();


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

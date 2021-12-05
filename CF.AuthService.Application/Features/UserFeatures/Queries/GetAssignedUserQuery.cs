
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
using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Common.Exceptions;

namespace CF.AuthService.Application.Features.UserFeatures.Queries
{
    public class GetAssignedUserQuery : IRequest<CustomResponse<AppUserDto>>
    {
        public string Area { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? FelStageId { get; set; }
        public Guid? ExceptedUserId { get; set; }
        public class GetAssignedUserHandler : IRequestHandler<GetAssignedUserQuery, CustomResponse<AppUserDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAssignedUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<AppUserDto>> Handle(GetAssignedUserQuery query, CancellationToken cancellationToken)
            {
                CustomResponse<AppUserDto> response = new CustomResponse<AppUserDto>();
                var userList = _unitOfWork.UserRepository.Filter(x => !x.IsDeleted && x.Id != new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"), // id admin account
                                        source => source.Include(x => x.Role).Include(x => x.FelStage)
                                    );

                userList = userList.Where(x => x.Area == query.Area);

                if (query.RoleId != null)
                {
                    userList = userList.Where(x => x.RoleId == query.RoleId);
                }

                if (query.FelStageId != null)
                {
                    userList = userList.Where(x => x.FelStageId == query.FelStageId);
                }

                if (query.ExceptedUserId != null)
                {
                    userList = userList.Where(x => x.Id != query.ExceptedUserId);
                }

                var result = _mapper.Map<AppUser, AppUserDto>(await userList.FirstOrDefaultAsync());

                response.Data = result;
                response.IsSucceed = true;
                response.Message = result == null ? "No user found" : "";
                return response;
            }
        }
    }
}

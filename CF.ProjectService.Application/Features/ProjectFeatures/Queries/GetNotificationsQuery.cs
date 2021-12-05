using AutoMapper;
using CF.ProjectService.Application.Common.Bases;
using CF.ProjectService.Application.Common.Constants;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Common.Response;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using Costimator.Application.Features.ProjectFeatures.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Queries
{
    public class GetNotificationsQuery : ResponsePaginationQuery<ProjectNotificationDto>
    {
        public class GetNotificationsHandle : IRequestHandler<GetNotificationsQuery, CustomResponse<PaginatedNotificationList<ProjectNotificationDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public GetNotificationsHandle(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<CustomResponse<PaginatedNotificationList<ProjectNotificationDto>>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
            {
                CustomResponse<PaginatedNotificationList<ProjectNotificationDto>> response = new CustomResponse<PaginatedNotificationList<ProjectNotificationDto>>();
                List<ProjectNotificationDto> listNoti = new List<ProjectNotificationDto>();
                var listNotiFromDb = _unitOfWork.NotificationRepository.Filter(x => x.ReceiverId == _loggedInUserService.Id && !x.IsDeleted)
                    .Include(x => x.ProjectRevision).ThenInclude(x => x.Project)
                    .Include(x => x.Sender)
                    .OrderByDescending(x => x.ActionOn)
                    .Select(x => new ProjectNotificationDto()
                    {
                        Id = x.Id,
                        Message = x.Message,
                        ProjectName = x.ProjectRevision.Project.Name,
                        RevisionId = x.RevisionId,
                        ActionOn = x.ActionOn,
                        ActionBy = _mapper.Map<AppUser, AppUserDto>(x.Sender),
                        IsRead = x.IsRead,
                        RevisionStatus = (int)x.RevisionStatus
                    });

                var totalNotReading = listNotiFromDb.Count(x => !x.IsRead);
                #region version 1
                /*var loggedInUserId = _loggedInUserService.Id;
                if (_loggedInUserService.User.RoleId != null)
                {
                    var roleId = _loggedInUserService.User.RoleId.Value;
                    if (roleId == RoleId.COE)
                    {
                        var projectRevisions = _unitOfWork.RevisionRepository
                            .Filter(x => !x.IsDeleted,
                                source => source.Include(y => y.Project).ThenInclude(y => y.ProjectUsers)
                                                .Include(y => y.RespondedByUser)
                                                .Include(y => y.ModifiedByUser))
                            //Type < 8 mean that COE has been assiged into project
                            .Where(x => (x.SubmittedByUserId == loggedInUserId && x.RevisionStatus == (int)RevisionStatus.Returned) || x.Project.ProjectUsers.Select(y => y.UserId).Contains(loggedInUserId))
                            .OrderByDescending(x => x.ModifiedOn);

                        foreach (var revision in projectRevisions)
                        {

                            ProjectNotificationDto proNoti = new ProjectNotificationDto()
                            {
                                //Message = "Project " + revision.Project.Name + " has been " + (revision.RevisionStatus == (int)RevisionStatus.Returned ? " returned" : " assigned to you"),
                                ProjectName = revision.Project.Name,
                                RevisionId = revision.Id,
                                //ActionOn = revision.ModifiedOn,
                                //ActionBy = _mapper.Map<AppUser, AppUserDto>(revision.SubmittedByUser),
                                IsRead = new Random().Next(11) <= 5 ? false : true,
                                RevisionStatus = revision.RevisionStatus
                            };

                            if (revision.SubmittedByUserId == loggedInUserId && revision.RevisionStatus == (int)RevisionStatus.Returned)
                            {
                                proNoti.Message = "Project " + revision.Project.Name + " has been returned to you";
                                proNoti.ActionOn = revision.RespondedOn;
                                proNoti.ActionBy = _mapper.Map<AppUser, AppUserDto>(revision.RespondedByUser);
                            }
                            else
                            {
                                proNoti.Message = "Project " + revision.Project.Name + " has been assigned to you";
                                proNoti.ActionOn = revision.ModifiedOn;
                                proNoti.ActionBy = _mapper.Map<AppUser, AppUserDto>(revision.ModifiedByUser);
                            }

                            listNoti.Add(proNoti);

                        }
                    }
                    else if (roleId == RoleId.FEE || roleId == RoleId.FEE_TP || roleId == RoleId.CE || roleId == RoleId.CE_TP)
                    {
                        var projectRevisions = _unitOfWork.RevisionRepository
                            .Filter(x => !x.IsDeleted && x.RevisionStatus == (int)RevisionStatus.PendingConceptDevelopmentAndCostEstimation,
                                source => source.Include(y => y.Project).ThenInclude(y => y.ProjectUsers))
                            //Type > 8 mean that FEE, FEE TP, CE, CE TP has been assiged into project
                            .Where(x => (x.Project.ProjectUsers.Where(y => y.Type >= 8).Select(y => y.UserId).Contains(loggedInUserId)))
                            .OrderByDescending(x => x.ModifiedOn);

                        foreach (var revision in projectRevisions)
                        {
                            ProjectNotificationDto proNoti = new ProjectNotificationDto()
                            {
                                Message = "Project " + revision.Project.Name + " has been assigned to you",
                                ProjectName = revision.Project.Name,
                                RevisionId = revision.Id,
                                ActionOn = revision.ModifiedOn,
                                //ActionBy = _mapper.Map<AppUser, AppUserDto>(revision.SubmittedByUser),
                                IsRead = new Random().Next(11) <= 5 ? false : true,
                                RevisionStatus = revision.RevisionStatus
                            };

                            listNoti.Add(proNoti);
                        }
                    }
                    else if (roleId == RoleId.FEE_TM)
                    {
                        var felStageId = _loggedInUserService.User.FelStageId;
                        var area = _loggedInUserService.User.Area;

                        var projectRevisions = _unitOfWork.RevisionRepository
                            .Filter(x => x.ProjectStageId == felStageId
                                    && x.Project.Area == area
                                    && x.IsDeleted == false
                                    && (x.RevisionStatus == (int)RevisionStatus.ReSubmitted || x.RevisionStatus == (int)RevisionStatus.PendingMobilisation),
                                source => source.Include(y => y.Project)
                                                .Include(y => y.SubmittedByUser))
                            .OrderByDescending(x => x.SubmittedOn);

                        foreach (var revision in projectRevisions)
                        {
                            ProjectNotificationDto proNoti = new ProjectNotificationDto()
                            {
                                Message = "Project " + revision.Project.Name + " has been " + (revision.RevisionStatus == (int)RevisionStatus.PendingMobilisation ? " submitted" : " resubmitted") + " to you",
                                ProjectName = revision.Project.Name,
                                RevisionId = revision.Id,
                                ActionOn = revision.ModifiedOn,
                                ActionBy = _mapper.Map<AppUser, AppUserDto>(revision.SubmittedByUser),
                                IsRead = new Random().Next(11) <= 5 ? false : true,
                                RevisionStatus = revision.RevisionStatus
                            };

                            listNoti.Add(proNoti);
                        }
                    }
                }*/
                #endregion

                response.Data = await listNotiFromDb.PaginatedNotificationListAsync(request.PageIndex, request.PageSize);
                response.Data.TotalNotReading = totalNotReading;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}

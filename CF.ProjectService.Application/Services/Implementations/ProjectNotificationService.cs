using AutoMapper;
using CF.ProjectService.Application.Common.Constants;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Implementations
{
    public class ProjectNotificationService : IProjectNotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ISignalrService _signalrService;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProjectNotificationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAuthService authService,
            ILoggedInUserService loggedInUserService,
            ISignalrService signalrService,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _unitOfWork = unitOfWork;
            _loggedInUserService = loggedInUserService;
            _signalrService = signalrService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }

        public async Task CoeSubmitProjectAsync(Guid revisionId)
        {
            var projectRevision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == revisionId,
                    source => source.Include(y => y.Project).Include(y => y.SubmittedByUser)
                );

            if (projectRevision != null)
            {
                var jwtToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"][0];
                var feeTm = await _authService.GetApproverAsync(projectRevision.Project.Area, RoleId.FEE_TM, projectRevision.ProjectStageId, jwtToken);

                if (feeTm != null)
                {
                    var existedNoti = await _unitOfWork.NotificationRepository.GetSingleAsync(x => x.SenderId == _loggedInUserService.Id
                                && x.ReceiverId == feeTm.Id && x.RevisionId == revisionId && x.RevisionStatus == (RevisionStatus)projectRevision.RevisionStatus
                            );

                    var notificationId = Guid.NewGuid();

                    if (existedNoti != null)
                    {
                        notificationId = existedNoti.Id;

                        existedNoti.Message = "Project " + projectRevision.Project.Name + " has been " + (projectRevision.RevisionStatus == (int)RevisionStatus.PendingMobilisation ? " submitted" : " resubmitted") + " to you";
                        existedNoti.ActionOn = DateTime.Now;
                        existedNoti.IsRead = false;

                        _unitOfWork.NotificationRepository.Update(existedNoti);
                    }
                    else
                    {
                        var notification = new ProjectNotification()
                        {
                            Id = notificationId,
                            SenderId = _loggedInUserService.Id,
                            ReceiverId = feeTm.Id,
                            RevisionId = revisionId,
                            Message = "Project " + projectRevision.Project.Name + " has been " + (projectRevision.RevisionStatus == (int)RevisionStatus.PendingMobilisation ? " submitted" : " resubmitted") + " to you",
                            ActionOn = DateTime.Now,
                            IsRead = false,
                            RevisionStatus = (RevisionStatus)projectRevision.RevisionStatus
                        };

                        _unitOfWork.NotificationRepository.Insert(notification);
                    }

                    ProjectNotificationDto proNoti = new ProjectNotificationDto()
                    {
                        Id = notificationId,
                        Message = "Project " + projectRevision.Project.Name + " has been " + (projectRevision.RevisionStatus == (int)RevisionStatus.PendingMobilisation ? " submitted" : " resubmitted") + " to you",
                        ProjectName = projectRevision.Project.Name,
                        RevisionId = projectRevision.Id,
                        ActionOn = projectRevision.ModifiedOn,
                        ActionBy = _mapper.Map<AppUser, AppUserDto>(projectRevision.SubmittedByUser),
                        IsRead = false,
                        RevisionStatus = projectRevision.RevisionStatus
                    };

                    await _signalrService.SendMessageToUserAsync(feeTm.Id, proNoti);
                }

            }

        }

        public async Task COEAssignOtherCOEAsync(ProjectRevision projectRevision, IEnumerable<Guid> listUserId)
        {
            foreach (var userId in listUserId.Distinct())
            {
                if (userId == _loggedInUserService.Id)
                {
                    continue;
                }

                var notification = new ProjectNotification()
                {
                    Id = Guid.NewGuid(),
                    SenderId = _loggedInUserService.Id,
                    ReceiverId = userId,
                    RevisionId = projectRevision.Id,
                    Message = "Project " + projectRevision.Project.Name + " has been assigned to you",
                    ActionOn = DateTime.Now,
                    IsRead = false,
                    RevisionStatus = (RevisionStatus)projectRevision.RevisionStatus
                };

                _unitOfWork.NotificationRepository.Insert(notification);

                ProjectNotificationDto proNoti = new ProjectNotificationDto()
                {
                    Id = notification.Id,
                    Message = "Project " + projectRevision.Project.Name + " has been assigned to you",
                    ProjectName = projectRevision.Project.Name,
                    RevisionId = projectRevision.Id,
                    ActionOn = projectRevision.RevisionStatus == (int)RevisionStatus.PendingMobilisation ? projectRevision.SubmittedOn : projectRevision.ModifiedOn,
                    ActionBy = _mapper.Map<AppUser, AppUserDto>(projectRevision.RevisionStatus == (int)RevisionStatus.PendingMobilisation ? projectRevision.SubmittedByUser : projectRevision.ModifiedByUser),
                    IsRead = false,
                    RevisionStatus = projectRevision.RevisionStatus
                };

                await _signalrService.SendMessageToUserAsync(userId, proNoti);
            }
        }

        public async Task TMAssignProjectAsync(ProjectRevision projectRevision, IEnumerable<Guid> listUserId)
        {
            foreach (var userId in listUserId.Distinct())
            {
                var notification = new ProjectNotification()
                {
                    Id = Guid.NewGuid(),
                    SenderId = _loggedInUserService.Id,
                    ReceiverId = userId,
                    RevisionId = projectRevision.Id,
                    Message = "Project " + projectRevision.Project.Name + " has been assigned to you",
                    ActionOn = DateTime.Now,
                    IsRead = false,
                    RevisionStatus = (RevisionStatus)projectRevision.RevisionStatus
                };

                _unitOfWork.NotificationRepository.Insert(notification);

                ProjectNotificationDto proNoti = new ProjectNotificationDto()
                {
                    Id = notification.Id,
                    Message = "Project " + projectRevision.Project.Name + " has been assigned to you",
                    ProjectName = projectRevision.Project.Name,
                    RevisionId = projectRevision.Id,
                    ActionOn = projectRevision.ModifiedOn,
                    ActionBy = _mapper.Map<AppUser, AppUserDto>(projectRevision.ModifiedByUser),
                    IsRead = false,
                    RevisionStatus = projectRevision.RevisionStatus
                };

                await _signalrService.SendMessageToUserAsync(userId, proNoti);
            }
        }

        public async Task TMReturnProjectAsync(Guid revisionId)
        {
            var projectRevision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == revisionId,
                    source => source.Include(y => y.Project)
                                    .Include(y => y.RespondedByUser)
                );

            var existedNoti = await _unitOfWork.NotificationRepository.GetSingleAsync(x => x.SenderId == _loggedInUserService.Id
                                && x.ReceiverId == projectRevision.SubmittedByUserId.Value && x.RevisionId == revisionId && x.RevisionStatus == (RevisionStatus)projectRevision.RevisionStatus
                            );

            var notificationId = Guid.NewGuid();

            if (existedNoti != null)
            {
                notificationId = existedNoti.Id;

                existedNoti.Message = "Project " + projectRevision.Project.Name + " has been returned to you";
                existedNoti.ActionOn = DateTime.Now;
                existedNoti.IsRead = false;

                _unitOfWork.NotificationRepository.Update(existedNoti);
            }
            else
            {
                var notification = new ProjectNotification()
                {
                    Id = notificationId,
                    SenderId = _loggedInUserService.Id,
                    ReceiverId = projectRevision.SubmittedByUserId.Value,
                    RevisionId = revisionId,
                    Message = "Project " + projectRevision.Project.Name + " has been returned to you",
                    ActionOn = DateTime.Now,
                    IsRead = false,
                    RevisionStatus = (RevisionStatus)projectRevision.RevisionStatus
                };

                _unitOfWork.NotificationRepository.Insert(notification);
            }

            ProjectNotificationDto proNoti = new ProjectNotificationDto()
            {
                Id = notificationId,
                Message = "Project " + projectRevision.Project.Name + " has been returned to you",
                ProjectName = projectRevision.Project.Name,
                RevisionId = projectRevision.Id,
                ActionOn = projectRevision.RespondedOn,
                ActionBy = _mapper.Map<AppUser, AppUserDto>(projectRevision.RespondedByUser),
                IsRead = false,
                RevisionStatus = projectRevision.RevisionStatus
            };

            await _signalrService.SendMessageToUserAsync(projectRevision.SubmittedByUserId.Value, proNoti);

        }

        public async Task UpdateReadingNotificationAsync(Guid notificationId)
        {
            var notification = await _unitOfWork.NotificationRepository.GetSingleAsync(x => x.Id == notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                notification.ReadOn = DateTime.Now;

                _unitOfWork.NotificationRepository.Update(notification);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}

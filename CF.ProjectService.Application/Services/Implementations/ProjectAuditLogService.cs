using AutoMapper;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Implementations
{
    public class ProjectAuditLogService : IProjectAuditLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;
        public ProjectAuditLogService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILoggedInUserService loggedInUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }

        public async Task AddLogProjectAsync(Guid revisionId, AuditLogStatus status, string remarks = null)
        {
            ProjectAuditLog log = new ProjectAuditLog()
            {
                Id = new Guid(),
                ActionByUserId = _loggedInUserService.Id,
                ActionOn = DateTime.Now,
                AuditLogStatus = status,
                RevisionId = revisionId
            };

            switch (status)
            {
                case AuditLogStatus.Submitted:
                    {
                        /*var logFromDb = await _unitOfWork.AuditLogRepository.GetSingleAsync(x => x.RevisionId == revisionId && x.AuditLogStatus == status && !x.IsDeleted);
                        if (logFromDb != null)
                        {
                            logFromDb.IsDeleted = true;
                            logFromDb.DeletedOn = DateTime.Now;
                            logFromDb.DeletedByUserId = _loggedInUserService.Id;
                            _unitOfWork.AuditLogRepository.Update(logFromDb);
                        }*/

                        log.Message = AuditLogMessage.COE_SubmitProject;
                        break;
                    }
                case AuditLogStatus.TeamAssigned:
                    {
                        log.Message = AuditLogMessage.TM_AssignTeam;
                        break;
                    }
                case AuditLogStatus.Returned:
                    {
                        log.Message = AuditLogMessage.TM_ReturnProject;
                        log.RespondedRemarks = remarks;
                        break;
                    }
                case AuditLogStatus.UpdatedEnvironmental:
                    {
                        log.Message = AuditLogMessage.UpdateEnviromental;
                        break;
                    }
                case AuditLogStatus.UpdatedInfrastructure:
                    {
                        log.Message = AuditLogMessage.UpdateInfrastructureData;
                        break;
                    }
                case AuditLogStatus.ReSubmitted:
                    {
                        log.Message = AuditLogMessage.COE_Resubmitted;
                        break;
                    }
                case AuditLogStatus.UpdatedWelCost:
                    {
                        log.Message = AuditLogMessage.UpdateWellCost;
                        break;
                    }
            }

            _unitOfWork.AuditLogRepository.Insert(log);
        }
    }
}

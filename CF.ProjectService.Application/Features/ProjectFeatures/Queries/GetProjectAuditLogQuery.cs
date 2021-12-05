using AutoMapper;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Response;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Queries
{
    public class GetProjectAuditLogQuery : IRequest<CustomResponse<List<AuditLogDto>>>
    {
        public Guid RevisionId { get; set; }
        public class GetProjectAuditLogQueryHandle : IRequestHandler<GetProjectAuditLogQuery, CustomResponse<List<AuditLogDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectDService _projectService;
            public GetProjectAuditLogQueryHandle(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IProjectDService projectService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _projectService = projectService;
            }

            public async Task<CustomResponse<List<AuditLogDto>>> Handle(GetProjectAuditLogQuery request, CancellationToken cancellationToken)
            {
                CustomResponse<List<AuditLogDto>> response = new CustomResponse<List<AuditLogDto>>();
                var logs = _unitOfWork.AuditLogRepository.Filter(
                        x => x.RevisionId == request.RevisionId,
                        source => source.Include(y => y.ProjectRevision).ThenInclude(y => y.Project)
                                        .Include(y => y.ActionByUser))
                    .OrderByDescending(x => x.ActionOn);

                response.Data = new List<AuditLogDto>();
                bool checkLastSubmit = false;
                bool checkLastUpdateEnv = false;
                bool checkLastUpdateInfra = false;
                bool checkLastUpdateWC = false;
                foreach (var log in logs)
                {
                    if ((log.AuditLogStatus == AuditLogStatus.Submitted && checkLastSubmit)
                        || log.AuditLogStatus == AuditLogStatus.ReSubmitted
                        || (log.AuditLogStatus == AuditLogStatus.UpdatedEnvironmental && checkLastUpdateEnv)
                        || (log.AuditLogStatus == AuditLogStatus.UpdatedInfrastructure && checkLastUpdateInfra)
                        || (log.AuditLogStatus == AuditLogStatus.UpdatedWelCost && checkLastUpdateWC)
                    )
                    {
                        continue;
                    }
                    else if (log.AuditLogStatus == AuditLogStatus.Submitted)
                    {
                        checkLastSubmit = true;
                    }
                    else if (log.AuditLogStatus == AuditLogStatus.UpdatedEnvironmental)
                    {
                        checkLastUpdateEnv = true;
                    }
                    else if (log.AuditLogStatus == AuditLogStatus.UpdatedInfrastructure)
                    {
                        checkLastUpdateInfra = true;
                    }
                    else if (log.AuditLogStatus == AuditLogStatus.UpdatedWelCost)
                    {
                        checkLastUpdateWC = true;
                    }

                    AuditLogDto logDto = new AuditLogDto();
                    logDto.AuditLogStatus = log.AuditLogStatus;
                    logDto.RevisionId = log.RevisionId;
                    logDto.ActionOn = log.ActionOn;
                    logDto.ActionByUserId = log.ActionByUserId;
                    logDto.RespondedRemarks = log.RespondedRemarks;
                    logDto.Message = log.Message;
                    //logDto.ProjectRevision = _mapper.Map<ProjectRevisionDto>(log.ProjectRevision);
                    logDto.ActionByUser = _mapper.Map<AppUserDto>(log.ActionByUser);

                    response.Data.Add(logDto);
                }

                response.IsSucceed = true;
                return response;
            }
        }
    }
}

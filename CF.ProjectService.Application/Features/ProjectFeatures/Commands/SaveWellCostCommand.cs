using AutoMapper;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Exceptions;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Response;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class SaveWellCostCommand : IRequest<CustomResponse<bool>>
    {
        public Guid RevisionId { get; set; }
        public GroupWellCostDto WellCosts { get; set; }

        public class SaveWellCostHandle : IRequestHandler<SaveWellCostCommand, CustomResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IProjectDService _projectService;
            private readonly IProjectAuditLogService _auditLogService;


            public SaveWellCostHandle(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IProjectAuditLogService auditLogService,
                IProjectDService projectService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _projectService = projectService;
                _auditLogService = auditLogService;
            }
            public async Task<CustomResponse<bool>> Handle(SaveWellCostCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var projectInvision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == request.RevisionId,
                        source => source.Include(x => x.Project).ThenInclude(x => x.ProjectUsers));

                // check permission
                if (!(await _projectService.CheckPermissionUserTrigger(projectInvision, ProjectTrigger.SaveWell)))
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Errors.Add(ExceptionMessages.UserPermissionAction);
                    return response;
                }

                var wellCostFromDb = _unitOfWork.WellCostRepository.Filter(x => x.RevisionId == request.RevisionId && !x.IsDeleted);

                await HandleSaveWellCost(request.RevisionId, wellCostFromDb, request.WellCosts.P10.OilProducer, WellCostType.P10_OilProducer);
                await HandleSaveWellCost(request.RevisionId, wellCostFromDb, request.WellCosts.P10.GasProducer, WellCostType.P10_GasProducer);
                await HandleSaveWellCost(request.RevisionId, wellCostFromDb, request.WellCosts.P50.OilProducer, WellCostType.P50_OilProducer);
                await HandleSaveWellCost(request.RevisionId, wellCostFromDb, request.WellCosts.P50.GasProducer, WellCostType.P50_GasProducer);
                await HandleSaveWellCost(request.RevisionId, wellCostFromDb, request.WellCosts.P90.OilProducer, WellCostType.P90_OilProducer);
                await HandleSaveWellCost(request.RevisionId, wellCostFromDb, request.WellCosts.P90.GasProducer, WellCostType.P90_GasProducer);

                await _projectService.UpdateProjectStatus(projectInvision, ProjectTrigger.SaveWell);

                await _unitOfWork.CommitAsync();

                await _auditLogService.AddLogProjectAsync(request.RevisionId, AuditLogStatus.UpdatedWelCost);

                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }

            private async Task HandleSaveWellCost(Guid RevisionId, IQueryable<WellCost> listWC, WellCostDto wcDto, WellCostType wcType)
            {
                var wcFromDb = await listWC.SingleOrDefaultAsync(x => x.Type == wcType);
                if (wcFromDb != null)
                {
                    wcFromDb = _mapper.Map(wcDto, wcFromDb);
                    _unitOfWork.WellCostRepository.Update(wcFromDb);
                }
                else
                {
                    WellCost newWcDb = _mapper.Map<WellCost>(wcDto);
                    newWcDb.Id = new Guid();
                    newWcDb.Type = wcType;
                    newWcDb.RevisionId = RevisionId;
                    _unitOfWork.WellCostRepository.Insert(newWcDb);
                }
            }
        }
    }
}

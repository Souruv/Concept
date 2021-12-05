using AutoMapper;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using Costimator.Application.Features.ProjectFeatures.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Queries
{
    public class GetProjectByIdQuery : IRequest<ProjectInfoDto>
    {
        // public Guid ProjectId { get; set; }
        public Guid RevisionId { get; set; }

        public class GetProjectByIdQueryHandle : IRequestHandler<GetProjectByIdQuery, ProjectInfoDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectDService _projectService;
            private readonly ICosmosDbService _cosmosDB;
            public GetProjectByIdQueryHandle(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IProjectDService projectService,
                ICosmosDbService cosmosDB)
            {
                _cosmosDB = cosmosDB;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _projectService = projectService;
            }

            public async Task<ProjectInfoDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
            {
                var projectRevision = _unitOfWork.RevisionRepository.Filter(x => x.IsDeleted == false && x.Id == request.RevisionId,
                   source => source.Include(x => x.CreatedByUser)
                     .Include(x => x.Project)
                     .Include(x => x.ProjectStage)
                     .Include(x => x.RespondedByUser)
                     .Include(x => x.Enviromental)
                     .Include(x => x.RevisionTeamMembers)
                     .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionCondensates)
                     .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionGas)
                     .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionOils)
                     .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionProducedWaters)
                     .Include(x => x.DrillingCenter)
                     .Include(x => x.WellCosts)
                   ).FirstOrDefault();

                var project = _unitOfWork.ProjectRepository.Filter(x => x.IsDeleted == false && x.Id == projectRevision.ProjectId,
                    source => source.Include(x => x.ProjectRevisions)
                    .Include(x => x.CreatedByUser)
                    .Include(x => x.ModifiedByUser)
                    .Include(x => x.ProjectNatureDetails).ThenInclude(y => y.ProjectNature)
                    .Include(x => x.ProjectUsers.Where(y => !y.IsDeleted)).ThenInclude(y => y.User)
                    ).FirstOrDefault();


                if (project == null) return null;

                var finalData = new ProjectInfoDto()
                {

                    Id = project.Id,
                    Pid = project.Pid,
                    Name = project.Name,
                    ProjectType = project.ProjectType,
                    Business = project.Business,
                    Area = project.Area,
                    Asset = project.Asset,
                    FileName = project.FileName,
                    CreatedByUser = _mapper.Map<AppUserDto>(project.CreatedByUser),
                    ModifiedByUser = _mapper.Map<AppUserDto>(project.ModifiedByUser),
                    CreatedOn = project.CreatedOn,
                    ModifiedOn = project.ModifiedOn,
                    ProjectUsers = _mapper.Map<List<ProjectUserDto>>(project.ProjectUsers),
                    Natures = _mapper.Map<List<ProjectNatureDto>>(project.ProjectNatureDetails.Where(x => !x.IsDeleted).Select(x => x.ProjectNature)),
                    ProjectRevisions = new ProjectRevisionDto()
                    {
                        Id = projectRevision.Id,
                        IsAcknowledged = projectRevision.IsAcknowledged,
                        ProjectId = projectRevision.ProjectId,
                        RevisionNo = projectRevision.RevisionNo,
                        RevisionStatus = (RevisionStatus)projectRevision.RevisionStatus,
                        CreatedOn = projectRevision.CreatedOn,
                        ModifiedOn = projectRevision.ModifiedOn,
                        CreatedByUser = _mapper.Map<AppUserDto>(projectRevision.CreatedByUser),
                        ProjectStage = _mapper.Map<ProjectStageDto>(projectRevision.ProjectStage),

                        RespondedOn = projectRevision.RespondedOn,
                        RespondedByUser = projectRevision.RespondedByUser,
                        RespondedRemarks = projectRevision.RespondedRemarks,

                        SubmittedOn = projectRevision.SubmittedOn,

                        ExpecedFirstResponseBy = projectRevision.ExpecedFirstResponseBy,
                        Remarks = projectRevision.Remarks,
                        ServiecRequestNUmber = projectRevision.ServiecRequestNUmber,
                        TargetUnitTechnicalCost = projectRevision.TargetUnitTechnicalCost,
                        Utc = projectRevision.UtcCountry,
                        RevisionTeamMembers = _mapper.Map<List<RevisionTeamMemberDto>>(projectRevision.RevisionTeamMembers),
                    },
                    Environmental = GetEnviromentalDto(projectRevision, project),
                    //_mapper.Map<EnviromentalDto>(projectRevision.Enviromental),
                    Infrastructure = GetInfrastructureDto(projectRevision),
                    WellCosts = await GetWellCostDto(projectRevision),
                    Approvers = await _projectService.GetApprovers(projectRevision)
                };

                return finalData;
            }

            private EnviromentalDto GetEnviromentalDto(ProjectRevision projectRevision, Project project)
            {
                return projectRevision.Enviromental != null ?
                    new EnviromentalDto()
                    {
                        Region = project.Area,
                        Location = "" + ((String.IsNullOrWhiteSpace(projectRevision.Enviromental.CoordinateLat) ? "" : projectRevision.Enviromental.CoordinateLat) + "," +
                        (String.IsNullOrWhiteSpace(projectRevision.Enviromental.CoordinateLon) ? "" : projectRevision.Enviromental.CoordinateLon)),
                        CoordinateLat = projectRevision.Enviromental.CoordinateLat,
                        CoordinateLon = projectRevision.Enviromental.CoordinateLon,

                        WaterDepthMin = projectRevision.DrillingCenter.Select(x => x.WaterDepth).DefaultIfEmpty().Min(),
                        WaterDepthMax = projectRevision.DrillingCenter.Select(x => x.WaterDepth).DefaultIfEmpty().Max(),

                        AmbientTemperatureMin = projectRevision.Enviromental.AmbientTemperatureMin,
                        AmbientTemperatureMinUnit = projectRevision.Enviromental.AmbientTemperatureMinUnit,

                        AmbientTemperatureMax = projectRevision.Enviromental.AmbientTemperatureMax,
                        AmbientTemperatureMaxUnit = projectRevision.Enviromental.AmbientTemperatureMaxUnit,


                        SeabedTemperatureMin = projectRevision.Enviromental.SeabedTemperatureMin,
                        SeabedTemperatureMinUnit = projectRevision.Enviromental.SeabedTemperatureMinUnit,

                        SeabedTemperatureMax = projectRevision.Enviromental.SeabedTemperatureMax,
                        SeabedTemperatureMaxUnit = projectRevision.Enviromental.SeabedTemperatureMaxUnit
                    }
                    : new EnviromentalDto()
                    {
                        Region = project.Area,
                        WaterDepthMin = projectRevision.DrillingCenter.Select(x => x.WaterDepth).DefaultIfEmpty().Min(),
                        WaterDepthMax = projectRevision.DrillingCenter.Select(x => x.WaterDepth).DefaultIfEmpty().Max(),
                    };
            }

            private InfrastructureDto GetInfrastructureDto(ProjectRevision projectRevision)
            {
                // list Evacuation Option Condensate
                List<EvacuationOptionCondensateDto> listEOCon = new List<EvacuationOptionCondensateDto>();
                if (projectRevision.InfrastructureData != null && projectRevision.InfrastructureData?.EvacuationOptionCondensates != null)
                {
                    foreach (var item in projectRevision.InfrastructureData?.EvacuationOptionCondensates)
                    {
                        EvacuationOptionCondensateDto dto = _mapper.Map<EvacuationOptionCondensateDto>(item);
                        dto.Distance = new DistanceOption()
                        {
                            FieldValue = item.DistanceValue,
                            Unit = item.DistanceUnit
                        };
                        dto.PressuresOperating = new PressuresOption()
                        {
                            FieldValue = item.PressuresOperatingValue,
                            Unit = item.PressuresOperatingUnit
                        };
                        dto.PressuresRated = new PressuresOption()
                        {
                            FieldValue = item.PressuresRatedValue,
                            Unit = item.PressuresRatedUnit
                        };
                        listEOCon.Add(dto);
                    }
                }


                // list Evacuation Option Gas
                List<EvacuationOptionGasDto> listEOGas = new List<EvacuationOptionGasDto>();
                if (projectRevision.InfrastructureData != null && projectRevision.InfrastructureData?.EvacuationOptionGas != null)
                {
                    foreach (var item in projectRevision.InfrastructureData?.EvacuationOptionGas)
                    {
                        EvacuationOptionGasDto dto = _mapper.Map<EvacuationOptionGasDto>(item);
                        dto.Distance = new DistanceOption()
                        {
                            FieldValue = item.DistanceValue,
                            Unit = item.DistanceUnit
                        };
                        dto.PressuresOperating = new PressuresOption()
                        {
                            FieldValue = item.PressuresOperatingValue,
                            Unit = item.PressuresOperatingUnit
                        };
                        dto.PressuresRated = new PressuresOption()
                        {
                            FieldValue = item.PressuresRatedValue,
                            Unit = item.PressuresRatedUnit
                        };

                        listEOGas.Add(dto);
                    }
                }

                // list Evacuation Option Oil
                List<EvacuationOptionOilDto> listEOOil = new List<EvacuationOptionOilDto>();
                if (projectRevision.InfrastructureData != null && projectRevision.InfrastructureData?.EvacuationOptionOils != null)
                {
                    foreach (var item in projectRevision.InfrastructureData?.EvacuationOptionOils)
                    {
                        EvacuationOptionOilDto dto = _mapper.Map<EvacuationOptionOilDto>(item);
                        dto.Distance = new DistanceOption()
                        {
                            FieldValue = item.DistanceValue,
                            Unit = item.DistanceUnit
                        };
                        dto.PressuresOperating = new PressuresOption()
                        {
                            FieldValue = item.PressuresOperatingValue,
                            Unit = item.PressuresOperatingUnit
                        };
                        dto.PressuresRated = new PressuresOption()
                        {
                            FieldValue = item.PressuresRatedValue,
                            Unit = item.PressuresRatedUnit
                        };

                        listEOOil.Add(dto);
                    }
                }

                // list Evacuation Option ProW
                List<EvacuationOptionProducedWaterDto> listEOProW = new List<EvacuationOptionProducedWaterDto>();
                if (projectRevision.InfrastructureData != null && projectRevision.InfrastructureData?.EvacuationOptionProducedWaters != null)
                {
                    foreach (var item in projectRevision.InfrastructureData?.EvacuationOptionProducedWaters)
                    {
                        EvacuationOptionProducedWaterDto dto = _mapper.Map<EvacuationOptionProducedWaterDto>(item);
                        dto.Distance = new DistanceOption()
                        {
                            FieldValue = item.DistanceValue,
                            Unit = item.DistanceUnit
                        };

                        listEOProW.Add(dto);
                    }
                }

                return new InfrastructureDto()
                {
                    //Region = project.Area,
                    //Location = "" + ((String.IsNullOrWhiteSpace(projectRevision.Enviromental.CoordinateLat) ? "" : projectRevision.Enviromental.CoordinateLat) + "," +
                    //(String.IsNullOrWhiteSpace(projectRevision.Enviromental.CoordinateLon) ? "" : projectRevision.Enviromental.CoordinateLon)),
                    EvacuationOptionsCondensate = listEOCon,
                    EvacuationOptionsGas = listEOGas,
                    EvacuationOptionsOil = listEOOil,
                    EvacuationOptionsProducedWater = listEOProW,
                };
            }

            private async Task<GroupWellCostDto> GetWellCostDto(ProjectRevision projectRevision)
            {
                var jsObject = new ExcelFieldsDataDto();
                jsObject = await _cosmosDB.GetItemAsync(projectRevision.Id.ToString());

                GroupWellCostDto wcDto = new GroupWellCostDto();
                if (jsObject != null && jsObject.DrillingCenter != null)
                {
                    wcDto.P10.SetOil(
                       _mapper.Map<WellCostDto>(projectRevision.WellCosts.FirstOrDefault(x => !x.IsDeleted && x.Type == WellCostType.P10_OilProducer)),
                       jsObject.DrillingCenter.Sum(x => x.P10.OilProducerWell));

                    wcDto.P10.SetGas(
                        _mapper.Map<WellCostDto>(projectRevision.WellCosts.FirstOrDefault(x => !x.IsDeleted && x.Type == WellCostType.P10_GasProducer)),
                        jsObject.DrillingCenter.Sum(x => x.P10.GasProducerWell));

                    wcDto.P50.SetOil(
                        _mapper.Map<WellCostDto>(projectRevision.WellCosts.FirstOrDefault(x => !x.IsDeleted && x.Type == WellCostType.P50_OilProducer)),
                        jsObject.DrillingCenter.Sum(x => x.P50.OilProducerWell));

                    wcDto.P50.SetGas(
                        _mapper.Map<WellCostDto>(projectRevision.WellCosts.FirstOrDefault(x => !x.IsDeleted && x.Type == WellCostType.P50_GasProducer)),
                        jsObject.DrillingCenter.Sum(x => x.P50.GasProducerWell));

                    wcDto.P90.SetOil(
                        _mapper.Map<WellCostDto>(projectRevision.WellCosts.FirstOrDefault(x => !x.IsDeleted && x.Type == WellCostType.P90_OilProducer)),
                         jsObject.DrillingCenter.Sum(x => x.P90.OilProducerWell));

                    wcDto.P90.SetGas(
                        _mapper.Map<WellCostDto>(projectRevision.WellCosts.FirstOrDefault(x => !x.IsDeleted && x.Type == WellCostType.P90_GasProducer)),
                        jsObject.DrillingCenter.Sum(x => x.P90.GasProducerWell));
                }

                wcDto.IsDone = _unitOfWork.AuditLogRepository.Filter(x => !x.IsDeleted && x.RevisionId == projectRevision.Id && x.AuditLogStatus == AuditLogStatus.UpdatedWelCost).FirstOrDefault() != null;
                return wcDto;
            }
        }
    }
}

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
using System.Linq.Dynamic.Core;
using CF.ProjectService.Application.Common.Bases;
using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using CF.ProjectService.Application.Common.Constants;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Queries
{
    public class GetFilteredProjectsQuery : BasePaginationQuery<ProjectBasicDto>
    {
        public Guid? CreatedBy { get; set; }
        public string? SearchText { get; set; } = string.Empty;
        public bool? IsDeleted { get; set; } = false;
        public string? ProjectType { get; set; }
        public string? ProjectStage { get; set; }
        public ProjectSearchType? SearchType { get; set; }
        public class GetFilteredProjectsQueryHandler : IRequestHandler<GetFilteredProjectsQuery, PaginatedList<ProjectBasicDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public GetFilteredProjectsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }




            public async Task<PaginatedList<ProjectBasicDto>> Handle(GetFilteredProjectsQuery query, CancellationToken cancellationToken)
            {
                var loggedInUserId = _loggedInUserService.Id;

                var projectList = _unitOfWork.ProjectRepository.Filter(x =>
                        x.ProjectRevisions.Any(y => y.IsDeleted == query.IsDeleted),
                        source => source.Include(x => x.CreatedByUser)
                         .Include(x => x.ProjectUsers)
                         .ThenInclude(x => x.User)
                        .Include(x => x.ModifiedByUser)
                        .Include(x => x.ProjectRevisions)
                        .ThenInclude(x => x.ProjectStage)
                        );

                //           var result = projectList
                //.Where("Field1=\"SomeValue\"")
                //.Select("new (Field1, Field2)");

                if (projectList == null)
                {
                    return null;
                }



                if (query.SearchType != null)
                {
                    if (query.SearchType == ProjectSearchType.MyProjectsOngoing)
                    {

                        //CE, pending cost analysis,6
                        if (_loggedInUserService.User.RoleId == RoleId.CE)
                        {
                            projectList = projectList.Where(x => x.ProjectRevisions.Any(y => y.RevisionStatus == (int)RevisionStatus.PendingCostAnalysis)
                            && x.ProjectUsers.Any(z => z.UserId == _loggedInUserService.User.Id && z.Type == (int)ProjectUserType.CEEngineer));
                        }

                        //FEE, pending concept development &cost estimate,4
                        else if (_loggedInUserService.User.RoleId == RoleId.FEE)
                        {
                            projectList = projectList.Where(x => x.ProjectRevisions.Any(y => y.RevisionStatus == (int)RevisionStatus.PendingConceptDevelopmentAndCostEstimation)
                            && x.ProjectUsers.Any(z => z.UserId == _loggedInUserService.User.Id && z.Type == (int)ProjectUserType.FEEngineer));
                        }
                        //COE, created by and shared with, all
                        else if (_loggedInUserService.User.RoleId == RoleId.COE)
                        {
                            projectList = projectList.Where(x => x.CreatedByUserId == _loggedInUserService.Id
                             || x.ProjectUsers.Any(u => u.UserId == _loggedInUserService.Id));
                        }
                        //FEE TM, same felstage & area, pending mobilization,2
                        else if (_loggedInUserService.User.RoleId == RoleId.FEE_TM)
                        {


                            projectList = projectList.Where(x => _loggedInUserService.User.Area == ProjectArea.AREA_ALL
                            || (_loggedInUserService.User.Area == x.Area)
                            || (ProjectArea.AREA_OUTSIDE_MALAYSIA == _loggedInUserService.User.Area && !ProjectArea.AREA_INSIDE_MALAYSIA.Contains(x.Area))
                            );

                            projectList = projectList.Where(x => x.ProjectRevisions.Any(y => y.ProjectStageId == _loggedInUserService.User.FelStageId
                           && (y.RevisionStatus == (int)RevisionStatus.PendingMobilisation || y.RevisionStatus == (int)RevisionStatus.ReSubmitted)));

                        }
                        //FEE TP, pending concept development &cost estimate,4
                        else if (_loggedInUserService.User.RoleId == RoleId.FEE_TP)
                        {
                            projectList = projectList.Where(x => x.ProjectRevisions.Any(y => y.RevisionStatus == (int)RevisionStatus.PendingConceptDevelopmentAndCostEstimation)
                            && x.ProjectUsers.Any(z => z.UserId == _loggedInUserService.User.Id && z.Type == (int)ProjectUserType.FETechnicalProfessional));
                        }
                        //CE TP, pending cost analysis,6
                        else if (_loggedInUserService.User.RoleId == RoleId.CE_TP)
                        {
                            projectList = projectList.Where(x => x.ProjectRevisions.Any(y => y.RevisionStatus == (int)RevisionStatus.PendingCostAnalysis)
                            && x.ProjectUsers.Any(z => z.UserId == _loggedInUserService.User.Id && z.Type == (int)ProjectUserType.CETechnicalProfessional));
                        }
                        else
                        {
                            projectList = projectList.Where(x => x.CreatedByUserId == _loggedInUserService.Id
                            || x.ProjectUsers.Any(u => u.UserId == _loggedInUserService.Id));
                        }

                    }
                    if (query.SearchType == ProjectSearchType.OtherProjectsOngoing)
                    {
                        projectList = projectList.Where(x => x.CreatedByUserId != _loggedInUserService.Id
                         && !x.ProjectUsers.Any(u => u.UserId == _loggedInUserService.Id));

                        if (query.ProjectType != "All")
                        {
                            projectList = projectList.Where(x => x.ProjectType == query.ProjectType);

                        }
                        if (query.ProjectStage != "All")
                        {
                            projectList = projectList.Where(x => x.ProjectRevisions.Any(y => y.ProjectStageId == new Guid(query.ProjectStage)));
                        }

                        if (_loggedInUserService.User.RoleId == RoleId.FEE_TM)
                        {
                            projectList = projectList.Where(x => x.ProjectRevisions.Any(y => y.ProjectStageId == _loggedInUserService.User.FelStageId));

                            projectList = projectList.Where(x =>
                            (
                                !(_loggedInUserService.User.Area == ProjectArea.AREA_ALL
                                || (_loggedInUserService.User.Area == x.Area)
                                || (ProjectArea.AREA_OUTSIDE_MALAYSIA == _loggedInUserService.User.Area && !ProjectArea.AREA_INSIDE_MALAYSIA.Contains(x.Area))
                                )

                            ) ||
                            (
                                 x.ProjectRevisions.Any(y => y.ProjectStageId != _loggedInUserService.User.FelStageId
                                 || !(y.RevisionStatus == (int)RevisionStatus.PendingMobilisation || y.RevisionStatus == (int)RevisionStatus.ReSubmitted))
                                 )
                            );

                        }

                    }

                }

                if (!string.IsNullOrEmpty(query.SearchText))
                {
                    projectList = projectList.Where(x => x.Name.Contains(query.SearchText));
                }

                IQueryable<ProjectBasicDto> finalQuery = null;


                finalQuery = projectList.Select(x => new ProjectBasicDto
                {
                    Id = x.Id,
                    Name = x.Name,

                    Pid = x.Pid,
                    Business = x.Business,
                    ProjectType = x.ProjectType,
                    ProjectUsers = _mapper.Map<List<ProjectUserDto>>(x.ProjectUsers.Where(sx => !sx.IsDeleted)),

                    Author = x.CreatedByUser.Name,
                    CreatedByUser = _mapper.Map<AppUserDto>(x.CreatedByUser),
                    ModifiedByUser = _mapper.Map<AppUserDto>(x.ModifiedByUser),
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    ProjectRevisions = x.ProjectRevisions
                    .Where(
                        rx =>
                        (query.SearchType == ProjectSearchType.OtherProjectsOngoing && _loggedInUserService.User.RoleId != RoleId.FEE_TM)
                        ||
                        (query.SearchType == ProjectSearchType.OtherProjectsOngoing && _loggedInUserService.User.RoleId == RoleId.FEE_TM
                         && (
                                !(rx.RevisionStatus == (int)RevisionStatus.PendingMobilisation || rx.RevisionStatus == (int)RevisionStatus.ReSubmitted)
                                || rx.ProjectStageId == _loggedInUserService.User.FelStageId
                            )
                        )
                        ||
                        //CE, pending cost analysis,6
                        (_loggedInUserService.User.RoleId == RoleId.CE
                            && rx.RevisionStatus == (int)RevisionStatus.PendingCostAnalysis
                            && x.ProjectUsers.Any(z => z.UserId == _loggedInUserService.User.Id && z.Type == (int)ProjectUserType.CEEngineer)
                        )
                        ||
                        //FEE, pending concept development &cost estimate,4
                        (_loggedInUserService.User.RoleId == RoleId.FEE
                            && rx.RevisionStatus == (int)RevisionStatus.PendingConceptDevelopmentAndCostEstimation
                            && x.ProjectUsers.Any(z => z.UserId == _loggedInUserService.User.Id && z.Type == (int)ProjectUserType.FEEngineer)
                        )
                        ||
                        //COE, created by and shared with, all -- no filtering needed here
                          (_loggedInUserService.User.RoleId == RoleId.COE && (
                                x.CreatedByUserId == _loggedInUserService.Id
                             || x.ProjectUsers.Any(u => u.UserId == _loggedInUserService.Id)
                             )
                           )
                        ||
                        //FEE TM, same felstage & area, pending mobilization,2
                        (_loggedInUserService.User.RoleId == RoleId.FEE_TM
                            && (rx.RevisionStatus == (int)RevisionStatus.PendingMobilisation || rx.RevisionStatus == (int)RevisionStatus.ReSubmitted)
                            && rx.ProjectStageId == _loggedInUserService.User.FelStageId
                        )
                        ||
                        //FEE TP, pending concept development &cost estimate,4
                        (_loggedInUserService.User.RoleId == RoleId.FEE_TP
                            && rx.RevisionStatus == (int)RevisionStatus.PendingConceptDevelopmentAndCostEstimation
                            && x.ProjectUsers.Any(z => z.UserId == _loggedInUserService.User.Id && z.Type == (int)ProjectUserType.FETechnicalProfessional)
                        )
                        ||
                        //CE TP, pending cost analysis,6
                        (_loggedInUserService.User.RoleId == RoleId.CE_TP
                            && rx.RevisionStatus == (int)RevisionStatus.PendingCostAnalysis
                            && x.ProjectUsers.Any(z => z.UserId == _loggedInUserService.User.Id && z.Type == (int)ProjectUserType.CETechnicalProfessional)
                        )


                    ).Select(s => new ProjectRevisionDto
                    {
                        Id = s.Id,
                        RevisionNo = s.RevisionNo,
                        SubmittedByUser = _mapper.Map<AppUserDto>(s.SubmittedByUser),
                        SubmittedByUserId = s.SubmittedByUserId ?? null,
                        RevisionStatus = (RevisionStatus)s.RevisionStatus,
                        CreatedOn = s.CreatedOn,
                        ModifiedOn = s.ModifiedOn,
                        RespondedRemarks = s.RespondedRemarks,
                        SubmittedOn = s.SubmittedOn,
                        Remarks = s.Remarks,
                        ProjectStage = _mapper.Map<ProjectStageDto>(s.ProjectStage),
                    }).ToList(),

                    LatestModifiedOn = x.LastModifiedOn,
                    LatestCreatedOn = x.LastCreatedOn,
                    LatestSubmittedOn = x.LastSubmittedOn,
                    LatestDeletedOn = x.LatestDeletedOn,
                    SubmittedBy = x.LastSubmittedByUser.Name
                });

                if (!string.IsNullOrEmpty(query.SortColumn))
                {
                    if (query.SortColumn == "name")
                    {
                        finalQuery = finalQuery.OrderBy(query.SortColumn + " " + query.SortDirection);
                    }
                    else
                    {
                        finalQuery = finalQuery.OrderBy(query.SortColumn + " " + query.SortDirection);

                    }
                }

                var result = await finalQuery
                .PaginatedListAsync(query.PageIndex, query.PageSize);



                return result;
            }
        }
    }
}

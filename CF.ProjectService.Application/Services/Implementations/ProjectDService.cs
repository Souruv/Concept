using AutoMapper;
using CF.ProjectService.Application.Common.Constants;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Exceptions;
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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Implementations
{
    public class ProjectDService : IProjectDService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEvacuationOptionService _evacuationService;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;
        private readonly IProjectNotificationService _projectNotificationService;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProjectDService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAuthService authService,
            IEvacuationOptionService evacuationService,
            IProjectNotificationService projectNotificationService,
            ILoggedInUserService loggedInUserService,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _evacuationService = evacuationService;
            _mapper = mapper;
            _authService = authService;
            _loggedInUserService = loggedInUserService;
            _projectNotificationService = projectNotificationService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GetNextUniqueProjectName(string baseProjectName)
        {
            var counter = 1;
            var fileNameToTry = baseProjectName;// + $" ({counter})";
            var isExist = true;

            while (isExist)
            {
                isExist = await _unitOfWork.ProjectRepository.IsFileNameExist(fileNameToTry);
                if (isExist)
                {
                    fileNameToTry = baseProjectName + $" ({counter++})";
                }
            }


            return fileNameToTry;
        }

        public async Task<string> GetNextPid()
        {
            var countProjects = await _unitOfWork.ProjectRepository.Filter(x => !x.IsDeleted).CountAsync();

            countProjects++;

            string pid = countProjects.ToString("00000");
            return pid;
        }

        public async Task<int> GetNextRevisionNo(Guid projectid)
        {
            var maxNo = await _unitOfWork.RevisionRepository.GetMaxRevisionNo(projectid);
            if (!maxNo.HasValue || maxNo < 1)
            {
                maxNo = 1;
            }
            else
            {
                maxNo++;

            }
            return (int)maxNo;
        }

        public async Task<bool> UpdateProjectEntity(ProjectRevision revision)
        {
            bool shouldUpdateProject = false;
            if (revision.IsDeleted)
            {
                var maxDeletedRevision = await _unitOfWork.RevisionRepository.GetMaxDeletedRevision(revision.Project.Id);

                if (maxDeletedRevision != null && maxDeletedRevision.RevisionNo == revision.RevisionNo)
                {

                    revision.Project.LatestDeletedOn = revision.DeletedOn;
                    shouldUpdateProject = true;

                    //await _unitOfWork.CommitAsync();
                }
            }
            var maxRevision = await _unitOfWork.RevisionRepository.GetMaxRevision(revision.Project.Id);
            if (maxRevision == null && revision.IsDeleted)
            {
                revision.Project.IsDeleted = true;
            }
            else if (maxRevision != null && maxRevision.RevisionNo == revision.RevisionNo)
            {

                revision.Project.LastCreatedOn = revision.CreatedOn;
                revision.Project.LastModifiedOn = revision.ModifiedOn;
                revision.Project.LastRevisionNo = revision.RevisionNo;
                revision.Project.LastRevisionStatus = revision.RevisionStatus;
                revision.Project.LastSubmittedOn = revision.SubmittedOn;
                revision.Project.LastSubmittedBy = revision.SubmittedByUserId;

                shouldUpdateProject = true;
            }

            if (shouldUpdateProject)
            {
                _unitOfWork.ProjectRepository.Update(revision.Project);
            }


            return true;
        }




        public async Task<bool> IsProjectNameExist(string projectName, Guid? projectId = null)
        {
            var query = this._unitOfWork.ProjectRepository.Filter(x => x.Name == projectName && !x.IsDeleted);

            if (projectId != null || projectId != Guid.Empty)
            {
                query = query.Where(x => x.Id != projectId);
            }


            return await query.AnyAsync();
        }

        public async Task<ProjectRevision> UpdateProjectInforAsync(ProjectRevision revisionFromDb, ProjectInfoPostDto projectInfoDto, ProjectTrigger? projectTrigger = null)
        {
            var listUserSendNoti = new List<Guid>();

            if (revisionFromDb != null)
            {
                if (await IsProjectNameExist(projectInfoDto.Name, revisionFromDb.Project.Id))
                {
                    return null;
                }

                #region Update Project Infor
                // update project
                var project = revisionFromDb.Project;
                project.Name = projectInfoDto.Name;
                project.ProjectType = projectInfoDto.ProjectType;
                project.Business = projectInfoDto.Business;
                project.Area = projectInfoDto.Area;
                project.Asset = projectInfoDto.Asset;
                project.FileName = projectInfoDto.File;


                _unitOfWork.ProjectRepository.Update(project);

                // update project revision
                revisionFromDb.ProjectStageId = projectInfoDto.Stage;
                revisionFromDb.Remarks = projectInfoDto.Remarks;
                revisionFromDb.ServiecRequestNUmber = projectInfoDto.ServiceRequest;
                revisionFromDb.ExpecedFirstResponseBy = projectInfoDto.ExpectedRespondDate;
                revisionFromDb.TargetUnitTechnicalCost = projectInfoDto.TargetUnitTechnicalCost;
                revisionFromDb.UtcCountry = projectInfoDto.Utc;

                if (projectTrigger != null)
                {
                    await UpdateProjectStatus(revisionFromDb, projectTrigger.Value);
                }

                _unitOfWork.RevisionRepository.Update(revisionFromDb);

                // update nature
                var listProjectNature = project.ProjectNatureDetails.Where(x => x.IsDeleted == false);

                foreach (var item in projectInfoDto.Nature)
                {
                    if (!listProjectNature.Select(x => x.ProjectNatureId).Contains(item))
                    {
                        var newProjectNatureDetail = new ProjectNatureDetail()
                        {
                            Id = Guid.NewGuid(),
                            ProjectNatureId = item,
                            ProjectId = project.Id

                        };
                        _unitOfWork.ProjectNatureDetailRepository.Insert(newProjectNatureDetail);
                    }
                }

                foreach (var item in listProjectNature.Select(x => x.ProjectNatureId))
                {
                    if (!projectInfoDto.Nature.Contains(item))
                    {
                        var projectNatureDetail = listProjectNature.FirstOrDefault(x => x.ProjectNatureId == item);
                        projectNatureDetail.IsDeleted = true;
                        projectNatureDetail.DeletedOn = DateTime.Now;
                        projectNatureDetail.DeletedByUserId = _loggedInUserService.User.Id;
                        _unitOfWork.ProjectNatureDetailRepository.Update(projectNatureDetail);
                    }

                }



                var projectManagerList = project.ProjectUsers.Where(x => x.IsDeleted == false && x.Type == (int)ProjectUserType.SubSurfaceProjectManager);
                var projectManagerListId = projectManagerList.Select(x => x.UserId);
                var listInsert = projectInfoDto.ProjectManagerList.Where(x => projectManagerListId.Contains(x.Id) == false);
                var listUpdate = projectManagerListId.Where(x => projectInfoDto.ProjectManagerList.Select(x => x.Id).Contains(x) == false);
                listUserSendNoti.AddRange(listInsert.Select(x => x.Id));

                foreach (var user in listUpdate)
                {
                    var projectManager = projectManagerList.FirstOrDefault(x => x.UserId == user);
                    projectManager.IsDeleted = true;
                    projectManager.DeletedOn = DateTime.Now;
                    projectManager.DeletedByUserId = _loggedInUserService.User.Id;
                    _unitOfWork.ProjectUserRepository.Update(projectManager);
                }

                foreach (var newUser in listInsert)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = project.Id,
                        UserId = newUser.Id,
                        Type = (int)ProjectUserType.SubSurfaceProjectManager,
                        CanEdit = false
                    };
                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }



                var productTechList = project.ProjectUsers.Where(x => x.IsDeleted == false && x.Type == (int)ProjectUserType.ProductionTechnologist);
                var productTechListId = productTechList.Select(x => x.UserId);
                var listInsertTech = projectInfoDto.ProductionTechnologistList.Where(x => productTechListId.Contains(x.Id) == false);
                var listUpdateTech = productTechListId.Where(x => projectInfoDto.ProductionTechnologistList.Select(x => x.Id).Contains(x) == false);
                listUserSendNoti.AddRange(listInsertTech.Select(x => x.Id));

                foreach (var user in listUpdateTech)
                {
                    var productTechnologist = productTechList.FirstOrDefault(x => x.UserId == user);
                    productTechnologist.IsDeleted = true;
                    productTechnologist.DeletedOn = DateTime.Now;
                    productTechnologist.DeletedByUserId = _loggedInUserService.User.Id;
                    _unitOfWork.ProjectUserRepository.Update(productTechnologist);
                }

                foreach (var newUser in listInsertTech)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = project.Id,
                        UserId = newUser.Id,
                        Type = (int)ProjectUserType.ProductionTechnologist,
                        CanEdit = false
                    };
                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }



                var projectGeologistList = project.ProjectUsers.Where(x => x.IsDeleted == false && x.Type == (int)ProjectUserType.Geologist);
                var projectGeologistId = projectGeologistList.Select(x => x.UserId);
                var listInsertGeologist = projectInfoDto.GeologistList.Where(x => projectGeologistId.Contains(x.Id) == false);
                var listUpdateGeologist = projectGeologistId.Where(x => projectInfoDto.GeologistList.Select(x => x.Id).Contains(x) == false);
                listUserSendNoti.AddRange(listInsertGeologist.Select(x => x.Id));

                foreach (var user in listUpdateGeologist)
                {
                    var projectGeologist = projectGeologistList.FirstOrDefault(x => x.UserId == user);
                    projectGeologist.IsDeleted = true;
                    projectGeologist.DeletedOn = DateTime.Now;
                    projectGeologist.DeletedByUserId = _loggedInUserService.User.Id;
                    _unitOfWork.ProjectUserRepository.Update(projectGeologist);
                }

                foreach (var newUser in listInsertGeologist)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = project.Id,
                        UserId = newUser.Id,
                        Type = (int)ProjectUserType.Geologist,
                        CanEdit = false
                    };
                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }



                var projectGeoPhysicList = project.ProjectUsers.Where(x => x.IsDeleted == false && x.Type == (int)ProjectUserType.GeoPhysicist);
                var projectGeoPhysicId = projectGeoPhysicList.Select(x => x.UserId);
                var listInsertGeoPhysic = projectInfoDto.GeoPhysicistList.Where(x => projectGeoPhysicId.Contains(x.Id) == false);
                var listUpdateGeoPhysic = projectGeoPhysicId.Where(x => projectInfoDto.GeoPhysicistList.Select(x => x.Id).Contains(x) == false);
                listUserSendNoti.AddRange(listInsertGeoPhysic.Select(x => x.Id));

                foreach (var user in listUpdateGeoPhysic)
                {
                    var projectGeophysic = projectGeoPhysicList.FirstOrDefault(x => x.UserId == user);
                    projectGeophysic.IsDeleted = true;
                    projectGeophysic.DeletedOn = DateTime.Now;
                    projectGeophysic.DeletedByUserId = _loggedInUserService.User.Id;
                    _unitOfWork.ProjectUserRepository.Update(projectGeophysic);
                }

                foreach (var newUser in listInsertGeoPhysic)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = project.Id,
                        UserId = newUser.Id,
                        Type = (int)ProjectUserType.GeoPhysicist,
                        CanEdit = false
                    };
                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }



                var projectReservoirList = project.ProjectUsers.Where(x => x.IsDeleted == false && x.Type == (int)ProjectUserType.ReservoirEngineer);
                var projectReservoirListId = projectReservoirList.Select(x => x.UserId);
                var listInsertReservoir = projectInfoDto.ReservoirEngineerList.Where(x => projectReservoirListId.Contains(x.Id) == false);
                var listUpdateReservoir = projectReservoirListId.Where(x => projectInfoDto.ReservoirEngineerList.Select(x => x.Id).Contains(x) == false);
                listUserSendNoti.AddRange(listInsertReservoir.Select(x => x.Id));

                foreach (var user in listUpdateReservoir)
                {
                    var projectReservoir = projectReservoirList.FirstOrDefault(x => x.UserId == user);
                    projectReservoir.IsDeleted = true;
                    projectReservoir.DeletedOn = DateTime.Now;
                    projectReservoir.DeletedByUserId = _loggedInUserService.User.Id;
                    _unitOfWork.ProjectUserRepository.Update(projectReservoir);
                }

                foreach (var newUser in listInsertReservoir)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = project.Id,
                        UserId = newUser.Id,
                        Type = (int)ProjectUserType.ReservoirEngineer,
                        CanEdit = false
                    };
                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }




                var projectPetroList = project.ProjectUsers.Where(x => x.IsDeleted == false && x.Type == (int)ProjectUserType.PetroPhysicist);
                var projectPetroListId = projectPetroList.Select(x => x.UserId);
                var listInsertPetro = projectInfoDto.PetroPhysicistList.Where(x => projectPetroListId.Contains(x.Id) == false);
                var listUpdatePetro = projectPetroListId.Where(x => projectInfoDto.PetroPhysicistList.Select(x => x.Id).Contains(x) == false);
                listUserSendNoti.AddRange(listInsertPetro.Select(x => x.Id));

                foreach (var user in listUpdatePetro)
                {
                    var projectPetro = projectPetroList.FirstOrDefault(x => x.UserId == user);
                    projectPetro.IsDeleted = true;
                    projectPetro.DeletedOn = DateTime.Now;
                    projectPetro.DeletedByUserId = _loggedInUserService.User.Id;
                    _unitOfWork.ProjectUserRepository.Update(projectPetro);
                }

                foreach (var newUser in listInsertPetro)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = project.Id,
                        UserId = newUser.Id,
                        Type = (int)ProjectUserType.PetroPhysicist,
                        CanEdit = false
                    };
                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }


                var projectWellList = project.ProjectUsers.Where(x => x.IsDeleted == false && x.Type == (int)ProjectUserType.WellsEngineer);
                var projectWellListId = projectWellList.Select(x => x.UserId);
                var listInsertWell = projectInfoDto.WellsEngineerList.Where(x => projectWellListId.Contains(x.Id) == false);
                var listUpdateWell = projectWellListId.Where(x => projectInfoDto.WellsEngineerList.Select(x => x.Id).Contains(x) == false);
                listUserSendNoti.AddRange(listInsertWell.Select(x => x.Id));

                foreach (var user in listUpdateWell)
                {
                    var projectWell = projectWellList.FirstOrDefault(x => x.UserId == user);
                    projectWell.IsDeleted = true;
                    projectWell.DeletedOn = DateTime.Now;
                    projectWell.DeletedByUserId = _loggedInUserService.User.Id;
                    _unitOfWork.ProjectUserRepository.Update(projectWell);
                }

                foreach (var newUser in listInsertWell)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = project.Id,
                        UserId = newUser.Id,
                        Type = (int)ProjectUserType.WellsEngineer,
                        CanEdit = false
                    };
                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }

                var projectCompList = project.ProjectUsers.Where(x => x.IsDeleted == false && x.Type == (int)ProjectUserType.CompletionEngineer);
                var projectCompListId = projectCompList.Select(x => x.UserId);
                var listInsertComp = projectInfoDto.CompletionEngineerList.Where(x => projectCompListId.Contains(x.Id) == false);
                var listUpdateComp = projectCompListId.Where(x => projectInfoDto.CompletionEngineerList.Select(x => x.Id).Contains(x) == false);
                listUserSendNoti.AddRange(listInsertComp.Select(x => x.Id));

                foreach (var user in listUpdateComp)
                {
                    var projectComp = projectCompList.FirstOrDefault(x => x.UserId == user);
                    projectComp.IsDeleted = true;
                    projectComp.DeletedOn = DateTime.Now;
                    projectComp.DeletedByUserId = _loggedInUserService.User.Id;
                    _unitOfWork.ProjectUserRepository.Update(projectComp);
                }

                foreach (var newUser in listInsertComp)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = project.Id,
                        UserId = newUser.Id,
                        Type = (int)ProjectUserType.CompletionEngineer,
                        CanEdit = false
                    };
                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }

                #endregion


            }
            else
            {
                if (await IsProjectNameExist(projectInfoDto.Name))
                {
                    return null;
                }

                #region Create Project Infor

                var newId = Guid.NewGuid();

                var newProject = new Project()
                {
                    Id = newId,
                    Name = projectInfoDto.Name,
                    Pid = await GetNextPid(),
                    ProjectType = projectInfoDto.ProjectType,
                    Business = projectInfoDto.Business,
                    Area = projectInfoDto.Area,
                    Asset = projectInfoDto.Asset,
                };

                foreach (var item in projectInfoDto.Nature)
                {
                    var newProjectNatureDetail = new ProjectNatureDetail()
                    {
                        Id = Guid.NewGuid(),
                        ProjectNatureId = item,
                        ProjectId = newProject.Id

                    };
                    _unitOfWork.ProjectNatureDetailRepository.Insert(newProjectNatureDetail);
                }

                listUserSendNoti.AddRange(projectInfoDto.ProjectManagerList.Select(x => x.Id));
                foreach (var user in projectInfoDto.ProjectManagerList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.SubSurfaceProjectManager,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                listUserSendNoti.AddRange(projectInfoDto.ProductionTechnologistList.Select(x => x.Id));
                foreach (var user in projectInfoDto.ProductionTechnologistList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.ProductionTechnologist,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                listUserSendNoti.AddRange(projectInfoDto.GeologistList.Select(x => x.Id));
                foreach (var user in projectInfoDto.GeologistList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.Geologist,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                listUserSendNoti.AddRange(projectInfoDto.GeoPhysicistList.Select(x => x.Id));
                foreach (var user in projectInfoDto.GeoPhysicistList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.GeoPhysicist,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                listUserSendNoti.AddRange(projectInfoDto.ReservoirEngineerList.Select(x => x.Id));
                foreach (var user in projectInfoDto.ReservoirEngineerList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.ReservoirEngineer,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                listUserSendNoti.AddRange(projectInfoDto.PetroPhysicistList.Select(x => x.Id));
                foreach (var user in projectInfoDto.PetroPhysicistList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.PetroPhysicist,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                listUserSendNoti.AddRange(projectInfoDto.WellsEngineerList.Select(x => x.Id));
                foreach (var user in projectInfoDto.WellsEngineerList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.WellsEngineer,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                _unitOfWork.ProjectRepository.Insert(newProject);


                revisionFromDb = new ProjectRevision()
                {
                    Id = Guid.NewGuid(),
                    ProjectId = newId,
                    RevisionNo = 1,
                    ProjectStageId = projectInfoDto.Stage,
                    RevisionStatus = (int)RevisionStatus.Draft,

                    ExpecedFirstResponseBy = projectInfoDto.ExpectedRespondDate,
                    Remarks = projectInfoDto.Remarks,
                    ServiecRequestNUmber = projectInfoDto.ServiceRequest,
                    TargetUnitTechnicalCost = projectInfoDto.TargetUnitTechnicalCost,
                    UtcCountry = projectInfoDto.Utc

                };

                // update revision status
                if (projectTrigger != null)
                {
                    await UpdateProjectStatus(revisionFromDb, projectTrigger.Value);
                }

                _unitOfWork.RevisionRepository.Insert(revisionFromDb);

                #endregion
            }

            await _projectNotificationService.COEAssignOtherCOEAsync(revisionFromDb, listUserSendNoti);
            return revisionFromDb;

        }

        public async Task UpdateProjectEnviromentAsync(ProjectRevision revisionFromDb, EnviromentalDto environmental)
        {
            if (revisionFromDb.Enviromental != null)
            {
                var enviromental = revisionFromDb.Enviromental;

                //enviromental.CoordinateLat = Environmental.CoordinateLat;
                //enviromental.CoordinateLon = Environmental.CoordinateLon;
                //enviromental.Location = Environmental.Location;
                enviromental.AmbientTemperatureMin = environmental.AmbientTemperatureMin;
                enviromental.AmbientTemperatureMinUnit = environmental.AmbientTemperatureMinUnit;
                enviromental.AmbientTemperatureMax = environmental.AmbientTemperatureMax;
                enviromental.AmbientTemperatureMaxUnit = environmental.AmbientTemperatureMaxUnit;
                enviromental.SeabedTemperatureMin = environmental.SeabedTemperatureMin;
                enviromental.SeabedTemperatureMinUnit = environmental.SeabedTemperatureMinUnit;
                enviromental.SeabedTemperatureMax = environmental.SeabedTemperatureMax;
                enviromental.SeabedTemperatureMaxUnit = environmental.SeabedTemperatureMaxUnit;

                _unitOfWork.EnviromentalRepository.Update(enviromental);
            }
            else
            {
                var enviromental = new Enviromental();

                enviromental.Id = Guid.NewGuid();
                enviromental.ProjectRevisionId = revisionFromDb.Id;
                //enviromental.CoordinateLat = Environmental.CoordinateLat;
                //enviromental.CoordinateLon = Environmental.CoordinateLon;
                //enviromental.Location = Environmental.Location;
                enviromental.AmbientTemperatureMin = environmental.AmbientTemperatureMin;
                enviromental.AmbientTemperatureMinUnit = environmental.AmbientTemperatureMinUnit;
                enviromental.AmbientTemperatureMax = environmental.AmbientTemperatureMax;
                enviromental.AmbientTemperatureMaxUnit = environmental.AmbientTemperatureMaxUnit;
                enviromental.SeabedTemperatureMin = environmental.SeabedTemperatureMin;
                enviromental.SeabedTemperatureMinUnit = environmental.SeabedTemperatureMinUnit;
                enviromental.SeabedTemperatureMax = environmental.SeabedTemperatureMax;
                enviromental.SeabedTemperatureMaxUnit = environmental.SeabedTemperatureMaxUnit;

                _unitOfWork.EnviromentalRepository.Insert(enviromental);
            }
        }

        public async Task UpdateProjectInfrastructureAsync(ProjectRevision revisionFromDb, InfrastructureDto infrastructure)
        {

            if (revisionFromDb.InfrastructureData != null)
            {
                var infraFromDb = revisionFromDb.InfrastructureData;

                // Evacuation Options Condensate
                var listEvaConden = infraFromDb.EvacuationOptionCondensates;
                foreach (var item in listEvaConden)
                {
                    /*item.IsDeleted = true;
                    _unitOfWork.EvacuationOptionCondensateRepository.Update(item);*/
                    _unitOfWork.EvacuationOptionCondensateRepository.Delete(item);
                }

                if (infrastructure.EvacuationOptionsCondensate != null)
                {
                    var listInsertEvaCo = infrastructure.EvacuationOptionsCondensate/*.Where(x => x.Id == null || x.Id == Guid.Empty)*/;
                    _evacuationService.InsertInfrastructureCondensate(listInsertEvaCo, infraFromDb.Id);
                }

                // Evacuation Options Gas
                var listEvaGas = infraFromDb.EvacuationOptionGas;
                foreach (var item in listEvaGas)
                {
                    _unitOfWork.EvacuationOptionGasRepository.Delete(item);
                }

                if (infrastructure.EvacuationOptionsGas != null)
                {
                    var listInsertEvaGas = infrastructure.EvacuationOptionsGas;
                    _evacuationService.InsertInfrastructureGas(listInsertEvaGas, infraFromDb.Id);
                }

                // Evacuation Options Oil
                var listEvaOil = infraFromDb.EvacuationOptionOils;
                foreach (var item in listEvaOil)
                {
                    _unitOfWork.EvacuationOptionOilRepository.Delete(item);
                }

                if (infrastructure.EvacuationOptionsOil != null)
                {
                    var listInsertEvaOil = infrastructure.EvacuationOptionsOil;
                    _evacuationService.InsertInfrastructureOil(listInsertEvaOil, infraFromDb.Id);
                }

                // Evacuation Options Produced Water
                var listEvaProW = infraFromDb.EvacuationOptionProducedWaters;
                foreach (var item in listEvaProW)
                {
                    _unitOfWork.EvacuationOptionProducedWaterRepository.Delete(item);
                }

                if (infrastructure.EvacuationOptionsProducedWater != null)
                {
                    var listInsertEvaProW = infrastructure.EvacuationOptionsProducedWater;
                    _evacuationService.InsertInfrastructureProducedWater(listInsertEvaProW, infraFromDb.Id);
                }
            }
            else
            {
                var infraStructure = new InfrastructureData();
                infraStructure.Id = Guid.NewGuid();
                infraStructure.ProjectRevisionId = revisionFromDb.Id;
                _unitOfWork.InfrastructureDataReporitory.Insert(infraStructure);

                var listInsertEvaCon = infrastructure.EvacuationOptionsCondensate;
                _evacuationService.InsertInfrastructureCondensate(listInsertEvaCon, infraStructure.Id);

                var listInsertEvaGas = infrastructure.EvacuationOptionsGas;
                _evacuationService.InsertInfrastructureGas(listInsertEvaGas, infraStructure.Id);

                var listInsertEvaOil = infrastructure.EvacuationOptionsOil;
                _evacuationService.InsertInfrastructureOil(listInsertEvaOil, infraStructure.Id);

                var listInsertEvaProW = infrastructure.EvacuationOptionsProducedWater;
                _evacuationService.InsertInfrastructureProducedWater(listInsertEvaProW, infraStructure.Id);
            }
        }

        public async Task UpdateProjectStatus(ProjectRevision revisionFromDb, ProjectTrigger projectTrigger, string responsedRemarks = null)
        {
            switch (projectTrigger)
            {
                case ProjectTrigger.Draft:
                    {
                        revisionFromDb.RevisionStatus = (int)RevisionStatus.Draft;
                        break;
                    }

                case ProjectTrigger.Submit:
                    {
                        revisionFromDb.Submit();
                        //revisionFromDb.RevisionStatus = (int)RevisionStatus.Submitted;
                        revisionFromDb.SubmittedByUserId = _loggedInUserService.Id;
                        //revisionFromDb.SubmittedOn = DateTime.Now;
                        break;
                    }

                case ProjectTrigger.Return:
                    {
                        revisionFromDb.Return();
                        //revisionFromDb.RevisionStatus = (int)RevisionStatus.Returned;
                        revisionFromDb.RespondedByUserId = _loggedInUserService.Id;
                        revisionFromDb.RespondedRemarks = responsedRemarks;
                        //revisionFromDb.RespondedOn = DateTime.Now;
                        break;
                    }

                case ProjectTrigger.AssignTeam:
                    {
                        revisionFromDb.AssignTeam();
                        break;
                    }

                case ProjectTrigger.SaveWell:
                    {
                        revisionFromDb.SaveWell();
                        break;
                    }
                default:
                    throw new Exception("Invalid Revision Status");
            }

            _unitOfWork.RevisionRepository.Update(revisionFromDb);
        }

        public async Task UpdateProjectTeamMembers(ProjectRevision revisionFromDb, TeamMembersDto teamMembers)
        {
            var existingFetm = revisionFromDb.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.FETechnicalProfessional).FirstOrDefault();

            if (teamMembers != null && teamMembers.FrontEndEngineerTechnical != null)
            {
                var newFetmId = teamMembers.FrontEndEngineerTechnical;

                if (existingFetm == null)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = revisionFromDb.Project.Id,
                        UserId = (Guid)teamMembers.FrontEndEngineerTechnical,
                        Type = (int)ProjectUserType.FETechnicalProfessional
                    };

                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }
                else if (newFetmId != existingFetm.UserId)
                {
                    existingFetm.UserId = (Guid)teamMembers.FrontEndEngineerTechnical;
                    _unitOfWork.ProjectUserRepository.Update(existingFetm);
                }

            }
            else
            {
                if (existingFetm != null)
                {
                    existingFetm.IsDeleted = true;
                    _unitOfWork.ProjectUserRepository.Update(existingFetm);
                }
            }



            if (teamMembers != null && teamMembers.FrontEndEngineers != null && teamMembers.FrontEndEngineers.Count() > 0)
            {
                var newFeEngIds = teamMembers.FrontEndEngineers.ToList();
                var existingFeEngIds = revisionFromDb.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.FEEngineer)
                    .Select(x => x.UserId).ToList();

                var tobeinsertedFeEngIdList = teamMembers.FrontEndEngineers.Where(x => !existingFeEngIds.Contains(x));

                var tobeDeletedFeEngList = revisionFromDb.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.FEEngineer
                 && !newFeEngIds.Contains(x.UserId));

                foreach (var userId in tobeinsertedFeEngIdList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = revisionFromDb.Project.Id,
                        UserId = userId,
                        Type = (int)ProjectUserType.FEEngineer

                    };

                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }
                foreach (var teamMember in tobeDeletedFeEngList)
                {
                    teamMember.IsDeleted = true;
                    _unitOfWork.ProjectUserRepository.Update(teamMember);
                }
            }
            else
            {
                var tobeDeletedFeEngList = revisionFromDb.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.FEEngineer);

                foreach (var teamMember in tobeDeletedFeEngList)
                {
                    teamMember.IsDeleted = true;
                    _unitOfWork.ProjectUserRepository.Update(teamMember);
                }
            }




            var existingCetm = revisionFromDb.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.CETechnicalProfessional).FirstOrDefault();

            if (teamMembers != null && teamMembers.CostEngineerTechnical != null)
            {
                var newCetmId = teamMembers.CostEngineerTechnical;


                if (existingCetm == null)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = revisionFromDb.Project.Id,
                        UserId = (Guid)teamMembers.CostEngineerTechnical,
                        Type = (int)ProjectUserType.CETechnicalProfessional
                    };

                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }
                else if (newCetmId != existingCetm.UserId)
                {
                    existingCetm.UserId = (Guid)teamMembers.CostEngineerTechnical;
                    _unitOfWork.ProjectUserRepository.Update(existingCetm);
                }

            }
            else
            {
                if (existingCetm != null)
                {
                    existingCetm.IsDeleted = true;
                    _unitOfWork.ProjectUserRepository.Update(existingCetm);
                }
            }




            if (teamMembers != null && teamMembers.CostEngineers != null && teamMembers.CostEngineers.Count() > 0)
            {
                var newCeEngIds = teamMembers.CostEngineers.ToList();
                var existingCeEngIds = revisionFromDb.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.CEEngineer)
                    .Select(x => x.UserId).ToList();

                var tobeinsertedCeEngIdList = teamMembers.CostEngineers.Where(x => !existingCeEngIds.Contains(x));

                var tobeDeletedCeEngList = revisionFromDb.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.CEEngineer
                 && !newCeEngIds.Contains(x.UserId));

                foreach (var userId in tobeinsertedCeEngIdList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = revisionFromDb.Project.Id,
                        UserId = userId,
                        Type = (int)ProjectUserType.CEEngineer

                    };

                    _unitOfWork.ProjectUserRepository.Insert(projectUser);
                }
                foreach (var teamMember in tobeDeletedCeEngList)
                {
                    teamMember.IsDeleted = true;
                    _unitOfWork.ProjectUserRepository.Update(teamMember);
                }
            }
            else
            {
                var tobeDeletedCeEngList = revisionFromDb.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.CEEngineer);

                foreach (var teamMember in tobeDeletedCeEngList)
                {
                    teamMember.IsDeleted = true;
                    _unitOfWork.ProjectUserRepository.Update(teamMember);
                }
            }

            revisionFromDb.IsAcknowledged = true;
            await UpdateProjectStatus(revisionFromDb, ProjectTrigger.AssignTeam);
            _unitOfWork.RevisionRepository.Update(revisionFromDb);
        }

        public async Task<List<ApproverDto>> GetApprovers(ProjectRevision revision)
        {
            var approvers = new List<ApproverDto>();
            var jwtToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"][0];
            if (String.IsNullOrEmpty(revision.Project.Area))
            {
                approvers.Add(await _authService.GetApproverAsync(ProjectArea.AREA_ALL, RoleId.FEE_TM, revision.ProjectStageId, jwtToken));
            }
            else if ((ProjectArea.AREA_INSIDE_MALAYSIA.Contains(revision.Project.Area)))
            {
                approvers.Add(await _authService.GetApproverAsync(revision.Project.Area, RoleId.FEE_TM, revision.ProjectStageId, jwtToken));
            }
            else
            {
                approvers.Add(await _authService.GetApproverAsync(ProjectArea.AREA_OUTSIDE_MALAYSIA, RoleId.FEE_TM, revision.ProjectStageId, jwtToken));
            }

            return approvers;
        }

        public async Task<bool> CheckPermissionUserTrigger(ProjectRevision revision, ProjectTrigger action)
        {
            // Assign Team or Return
            if ((revision.RevisionStatus == (int)RevisionStatus.PendingMobilisation
                    || revision.RevisionStatus == (int)RevisionStatus.ReSubmitted)
                && (action == ProjectTrigger.AssignTeam || action == ProjectTrigger.Return))
            {
                var approvers = await GetApprovers(revision);
                return approvers.Any(x => x.Id == _loggedInUserService.Id);
            }
            // Submit or Resubmit
            else if ((revision.RevisionStatus == (int)RevisionStatus.Draft
                    || revision.RevisionStatus == (int)RevisionStatus.PendingMobilisation
                    || revision.RevisionStatus == (int)RevisionStatus.ReSubmitted)
                && action == ProjectTrigger.Submit)
            {
                return revision.Project.ProjectUsers.Any(x => x.UserId == _loggedInUserService.Id
                    && x.Type == (int)ProjectUserType.SubSurfaceProjectManager)
                    || revision.CreatedByUserId == _loggedInUserService.Id;
            }
            else if (action == ProjectTrigger.SaveWell)
            {
                return revision.Project.ProjectUsers.Any(x => x.UserId == _loggedInUserService.Id
                    && (x.Type == (int)ProjectUserType.WellsEngineer
                        || x.Type == (int)ProjectUserType.CompletionEngineer));
            }

            return true;
        }

    }
}

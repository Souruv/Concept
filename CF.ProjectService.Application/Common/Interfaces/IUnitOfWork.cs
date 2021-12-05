using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CF.ProjectService.Application.Common.Interfaces;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities.Base;

namespace CF.ProjectService.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {

        public IProjectStageRepository ProjectStageRepository { get; }
        public IUserRepository UserRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public IProjectAuditLogRepository AuditLogRepository { get; }
        public IProjectNotificationRepository NotificationRepository { get; }
        public IRevisionRepository RevisionRepository { get; }

        public IProjectUserRepository ProjectUserRepository { get; }


        public IFieldsDataRepository FieldsDataRepository { get; }
        public IInfrastructureDataReporitory InfrastructureDataReporitory { get; }
        public IWellCostRepository WellCostRepository { get; }

        public IEnviromentalRepository EnviromentalRepository { get; }

        public IUpstreamMetricColumnRepository UpstreamMetricColumnRepository { get; }

        public IProjectNatureRepository ProjectNatureRepository { get; }

        public IEvacuationOptionRepository EvacuationOptionRepository { get; }

        public IEvacuationOptionCondensateRepository EvacuationOptionCondensateRepository { get; }

        public IEvacuationOptionGasRepository EvacuationOptionGasRepository { get; }
        public IEvacuationOptionOilRepository EvacuationOptionOilRepository { get; }
        public IEvacuationOptionProducedWaterRepository EvacuationOptionProducedWaterRepository { get; }

        public IProjectNatureDetailRepository ProjectNatureDetailRepository { get; }

        public IUTCCostRepository UTCCostRepository { get; }

        public ICountryRepository CountryRepository { get; }
        public IDrillingCenterRepository DrillingCenterRepository { get; }
        public ICoeInputP10Repository CoeInputP10Repository { get; }
        public ICoeInputP50Repository CoeInputP50Repository { get; }
        public ICoeInputP90Repository CoeInputP90Repository { get; }
        public ILookUpCraSCurveValueRepository LookUpCraSCurveValueRepository { get; }

        public ILookUpCraPdfXValueRepository LookUpCraPdfXValueRepository { get; }
        public ILookUpCraPdfYValueRepository LookUpCraPdfYValueRepository { get; }

        public ILookUpCraAccuracyExpressionRepository LookUpCraAccuracyExpressionRepository { get; }
        public ILookUpCraContingencyExpressionRepository LookUpCraContingencyExpressionRepository { get; }

        public IProjectDeterministicValueRepository ProjectDeterministicValueRepository { get; }
        public IDeterministicValueRepository DeterministicValueRepository { get; }



        public int Commit();
        public Task<int> CommitAsync();
        public void DetachEntity<T>(T entity);
    }
}

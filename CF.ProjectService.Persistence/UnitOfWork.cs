using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities.Base;
using CF.ProjectService.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Persistence
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;
        private IProjectAuditLogRepository _auditLogRepository;
        private IProjectNotificationRepository _notificationRepository;
        private IRevisionRepository _revisionRepository;
        private IProjectStageRepository _projectStageRepository;
        private IProjectUserRepository _projectUserRepository;
        private IFieldsDataRepository _fieldsDataRepository;
        private IInfrastructureDataReporitory _infrastructureDataRepository;
        private IWellCostRepository _wellCostRepository;
        private IUpstreamMetricColumnRepository _upstreamMetricColumnRepository;
        private IEnviromentalRepository _enviromentalRepository;
        private IProjectNatureRepository _projectNatureRepository;
        private IEvacuationOptionRepository _evacuationOptionRepository;
        private IEvacuationOptionCondensateRepository _evacuationOptionCondensateRepository;
        private IEvacuationOptionGasRepository _evacuationOptionGasRepository;
        private IEvacuationOptionOilRepository _evacuationOptionOilRepository;
        private IEvacuationOptionProducedWaterRepository _evacuationOptionProducedWaterRepository;
        private IProjectNatureDetailRepository _projectNatureDetailRepository;
        private IUTCCostRepository _utcCostRepository;
        private ICountryRepository _countryRepository;
        private IDrillingCenterRepository _drillingCenterRepository;
        private ICoeInputP10Repository _coeInputP10Repository;
        private ICoeInputP50Repository _coeInputP50Repository;
        private ICoeInputP90Repository _coeInputP90Repository;
        private ILookUpCraSCurveValueRepository _sCurveCalcs;
        private ILookUpCraPdfXValueRepository _pdfXValuesRepository;
        private ILookUpCraPdfYValueRepository _pdfYValuesRepository;
        private ILookUpCraAccuracyExpressionRepository _LookUpCraAccuracyExpressionRepository;
        private ILookUpCraContingencyExpressionRepository _LookUpCraContingencyExpressionRepository;
        private IProjectDeterministicValueRepository _ProjectDeterministicValueRepository;
        private IDeterministicValueRepository _DeterministicValueRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUpstreamMetricColumnRepository UpstreamMetricColumnRepository
        {
            get
            {
                if (this._upstreamMetricColumnRepository == null)
                {
                    this._upstreamMetricColumnRepository = new UpstreamMetricColumnRepository(_context);
                }

                return _upstreamMetricColumnRepository;
            }
        }

        public IProjectStageRepository ProjectStageRepository
        {
            get
            {
                if (this._projectStageRepository == null)
                {
                    this._projectStageRepository = new ProjectStageRepository(_context);
                }

                return _projectStageRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {

                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }
        public IProjectRepository ProjectRepository
        {
            get
            {

                if (this._projectRepository == null)
                {
                    this._projectRepository = new ProjectRepository(_context);
                }
                return _projectRepository;
            }
        }

        public IProjectAuditLogRepository AuditLogRepository
        {
            get
            {

                if (this._auditLogRepository == null)
                {
                    this._auditLogRepository = new ProjectAuditLogRepository(_context);
                }
                return _auditLogRepository;
            }
        }

        public IProjectNotificationRepository NotificationRepository
        {
            get
            {

                if (this._notificationRepository == null)
                {
                    this._notificationRepository = new ProjectNotificationRepository(_context);
                }
                return _notificationRepository;
            }
        }

        public IRevisionRepository RevisionRepository
        {
            get
            {

                if (this._revisionRepository == null)
                {
                    this._revisionRepository = new RevisionRepository(_context);
                }
                return _revisionRepository;
            }
        }

        public IProjectStageRepository projectStageRepository
        {
            get
            {
                if (this._projectStageRepository == null)
                {
                    this._projectStageRepository = new ProjectStageRepository(_context);
                }
                return _projectStageRepository;
            }
        }

        public IProjectUserRepository ProjectUserRepository
        {
            get
            {
                if (this._projectUserRepository == null)
                {
                    this._projectUserRepository = new ProjectUserRepository(_context);
                }
                return _projectUserRepository;
            }
        }

        public IFieldsDataRepository FieldsDataRepository
        {
            get
            {
                if (this._fieldsDataRepository == null)
                {
                    this._fieldsDataRepository = new FieldsDataRepository(_context);
                }
                return _fieldsDataRepository;
            }
        }
        public IInfrastructureDataReporitory InfrastructureDataReporitory
        {
            get
            {
                if (this._infrastructureDataRepository == null)
                {
                    this._infrastructureDataRepository = new InfrastructureRepository(_context);
                }
                return _infrastructureDataRepository;
            }
        }

        public IWellCostRepository WellCostRepository
        {
            get
            {
                if (this._wellCostRepository == null)
                {
                    this._wellCostRepository = new WellCostRepository(_context);
                }
                return _wellCostRepository;
            }
        }

        public IEnviromentalRepository EnviromentalRepository
        {
            get
            {
                if (this._enviromentalRepository == null)
                {
                    this._enviromentalRepository = new EnviromentalRepository(_context);
                }
                return _enviromentalRepository;
            }
        }


        public IProjectNatureRepository ProjectNatureRepository
        {
            get
            {
                if (this._projectNatureRepository == null)
                {
                    this._projectNatureRepository = new ProjectNatureRepository(_context);
                }
                return _projectNatureRepository;
            }
        }

        public IEvacuationOptionRepository EvacuationOptionRepository
        {
            get
            {
                if (this._evacuationOptionRepository == null)
                {
                    this._evacuationOptionRepository = new EvacuationOptionRepository(_context);
                }
                return _evacuationOptionRepository;
            }
        }

        public IEvacuationOptionCondensateRepository EvacuationOptionCondensateRepository
        {
            get
            {
                if (this._evacuationOptionCondensateRepository == null)
                {
                    this._evacuationOptionCondensateRepository = new EvacuationOptionCondensateRepository(_context);
                }
                return _evacuationOptionCondensateRepository;
            }
        }

        public IEvacuationOptionGasRepository EvacuationOptionGasRepository
        {
            get
            {
                if (this._evacuationOptionGasRepository == null)
                {
                    this._evacuationOptionGasRepository = new EvacuationOptionGasRepository(_context);
                }
                return _evacuationOptionGasRepository;
            }
        }

        public IEvacuationOptionOilRepository EvacuationOptionOilRepository
        {
            get
            {
                if (this._evacuationOptionOilRepository == null)
                {
                    this._evacuationOptionOilRepository = new EvacuationOptionOilRepository(_context);
                }
                return _evacuationOptionOilRepository;
            }
        }

        public IEvacuationOptionProducedWaterRepository EvacuationOptionProducedWaterRepository
        {
            get
            {
                if (this._evacuationOptionProducedWaterRepository == null)
                {
                    this._evacuationOptionProducedWaterRepository = new EvacuationOptionProducedWaterRepository(_context);
                }
                return _evacuationOptionProducedWaterRepository;
            }
        }

        public IProjectNatureDetailRepository ProjectNatureDetailRepository
        {
            get
            {
                if (this._projectNatureDetailRepository == null)
                {
                    this._projectNatureDetailRepository = new ProjectNatureDetailRepository(_context);
                }
                return _projectNatureDetailRepository;
            }
        }

        public IUTCCostRepository UTCCostRepository
        {
            get
            {
                if (this._utcCostRepository == null)
                {
                    this._utcCostRepository = new UTCCostRepository(_context);
                }
                return _utcCostRepository;
            }
        }


        public ICountryRepository CountryRepository
        {
            get
            {
                if (this._countryRepository == null)
                {
                    this._countryRepository = new CountryRepository(_context);
                }
                return _countryRepository;
            }
        }

        public IDrillingCenterRepository DrillingCenterRepository
        {
            get
            {
                if (this._drillingCenterRepository == null)
                {
                    this._drillingCenterRepository = new DrillingCenterRepository(_context);
                }
                return _drillingCenterRepository;
            }
        }

        public ICoeInputP10Repository CoeInputP10Repository
        {
            get
            {
                if (this._coeInputP10Repository == null)
                {
                    this._coeInputP10Repository = new CoeInputP10Repository(_context);
                }
                return _coeInputP10Repository;
            }
        }

        public ICoeInputP50Repository CoeInputP50Repository
        {
            get
            {
                if (this._coeInputP50Repository == null)
                {
                    this._coeInputP50Repository = new CoeInputP50Repository(_context);
                }
                return _coeInputP50Repository;
            }
        }

        public ICoeInputP90Repository CoeInputP90Repository
        {
            get
            {
                if (this._coeInputP90Repository == null)
                {
                    this._coeInputP90Repository = new CoeInputP90Repository(_context);
                }
                return _coeInputP90Repository;
            }
        }

        public ILookUpCraSCurveValueRepository LookUpCraSCurveValueRepository
        {
            get
            {
                if (this._sCurveCalcs == null)
                {
                    this._sCurveCalcs = new LookUpCraSCurveValueRepository(_context);
                }
                return _sCurveCalcs;
            }
        }

        public ILookUpCraPdfXValueRepository LookUpCraPdfXValueRepository
        {
            get
            {
                if (this._pdfXValuesRepository == null)
                {
                    this._pdfXValuesRepository = new LookUpCraPdfXValueRepository(_context);
                }
                return _pdfXValuesRepository;
            }
        }

        public ILookUpCraPdfYValueRepository LookUpCraPdfYValueRepository
        {
            get
            {
                if (this._pdfYValuesRepository == null)
                {
                    this._pdfYValuesRepository = new LookUpCraPdfYValueRepository(_context);
                }
                return _pdfYValuesRepository;
            }
        }

        public ILookUpCraAccuracyExpressionRepository LookUpCraAccuracyExpressionRepository
        {
            get
            {
                if (this._LookUpCraAccuracyExpressionRepository == null)
                {
                    this._LookUpCraAccuracyExpressionRepository = new LookUpCraAccuracyExpressionRepository(_context);
                }
                return _LookUpCraAccuracyExpressionRepository;
            }
        }
        public ILookUpCraContingencyExpressionRepository LookUpCraContingencyExpressionRepository
        {
            get
            {
                if (this._LookUpCraContingencyExpressionRepository == null)
                {
                    this._LookUpCraContingencyExpressionRepository = new LookUpCraContingencyExpressionRepository(_context);
                }
                return _LookUpCraContingencyExpressionRepository;
            }
        }

        public IProjectDeterministicValueRepository ProjectDeterministicValueRepository
        {
            get
            {
                if (this._ProjectDeterministicValueRepository == null)
                {
                    this._ProjectDeterministicValueRepository = new ProjectDeterministicValueRepository(_context);
                }
                return _ProjectDeterministicValueRepository;
            }

        }

        public IDeterministicValueRepository DeterministicValueRepository
        {
            get
            {
                if (this._DeterministicValueRepository == null)
                {
                    this._DeterministicValueRepository = new DeterministicValueRepository(_context);
                }
                return _DeterministicValueRepository;
            }

        }

        //public IFieldsDataRepository FieldsDataRepository 
        //{
        //    get
        //    {
        //        if (this._fieldsDataRepository == null)
        //        {
        //            this._fieldsDataRepository = new FieldsDataRepository(_context);
        //        }
        //        return _fieldsDataRepository;
        //    }
        //}
        //public IInfrastructureDataReporitory InfrastructureDataReporitory 
        //{
        //    get
        //    {
        //        if (this._infrastructureDataReporitory == null)
        //        {
        //            this._infrastructureDataReporitory = new InfrastructureRepository(_context);
        //        }
        //        return _infrastructureDataReporitory;
        //    }
        //}


        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /*
         public static void DetachLocal<T>(this DbContext context, T t, string entryId) 
    where T : class, IIdentifier 
{
    var local = context.Set<T>()
        .Local
        .FirstOrDefault(entry => entry.Id.Equals(entryId));
    if (!local.IsNull())
    {
        context.Entry(local).State = EntityState.Detached;
    }
    context.Entry(t).State = EntityState.Modified;
}
        */
        //public  void DetachEntity<T>( BaseEntity entity)
        //{

        //        var dbEntity =  _context.FindAsync<BaseEntity>(entity.Id);
        //        if (dbEntity != null)
        //            _context.Entry(dbEntity).State = EntityState.Detached;

        //}

        public void DetachEntity<T>(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

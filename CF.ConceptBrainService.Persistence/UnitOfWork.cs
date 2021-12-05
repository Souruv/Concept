using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities.Base;
using CF.ConceptBrainService.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Persistence
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IUserRepository _userRepository;
        public IPipelineRatingRepository _pipelineRatingRepository;
        public IFlowlineBoundaryRepository _flowlineBoundaryRepository;
        public ILiquidPipelineSizeBoundaryRepository _liquidPipelineSizeBoundaryRepository;
        public IPipelineSizeCalcRepository _pipelineSizeCalcRepository;
        public IBrainTreeTypeRepository _brainTreeTypeRepository;
        public IBrainWaterDisposalRepository _brainWaterDisposalRepository;
        public IBrainPWTInjectionRepository _brainPwtInjectionRepository;
        public IBrainExternalWaterInjectionRepository _brainExternalWaterInjectionRepository;
        private IEquipmentRepository _equimentRepository;
        private ILookupGenericWeightEstimateRepository _weightEstimateRepositry;
        private IEquipmentMasterRepository _equipmentMasterRepository;

        private ILevelInformationRepository _levelInformationRepository;
        public IBrainFieldTableMappingRepository _brainFieldTableMappingRepository;
        public IBrainTableColumnConfigurationRepository _brainTableColumnConfigurationRepository;
        public IBrainOilHandlingRepository _brainOilHandlingRepository;
        public IBrainGasDisposalRepository _brainGasDisposalRepository;
        public IBrainGasExportRepository _brainGasExportRepository;
        public IBrainGasInjectionRepository _brainGasInjectionRepository;
        public IBrainGasContaminantMgmtRepository _brainGasContaminantMgmtRepository;
        public IBrainCondensateHandlingRepository _brainCondensateHandlingRepository;
        public IBrainSubstructureRepository _brainSubstructureRepository;
        public IBrainPressureProtectionRepository _brainPressureProtectionRepository;
        public IBrainAccommodationRepository _brainAccommodationRepository;
        public IBrainDrillingAndWorkoverStrategyRepository _brainDrillingAndWorkoverStrategyRepository;
        public IProjectConceptQueueRepository _projectConceptQueueRepository;
        public IConceptRepository _conceptRepository;
        public IConceptDCDetailsRepository _conceptDCDetailsRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
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
        public IPipelineRatingRepository PipelineRatingRepository
        {
            get
            {

                if (this._pipelineRatingRepository == null)
                {
                    this._pipelineRatingRepository = new PipelineRatingRepository(_context);
                }
                return _pipelineRatingRepository;
            }
        }

        public ILiquidPipelineSizeBoundaryRepository LiquidPipelineSizeBoundaryRepository
        {
            get
            {

                if (this._liquidPipelineSizeBoundaryRepository == null)
                {
                    this._liquidPipelineSizeBoundaryRepository = new LiquidPipelineSizeBoundaryRepository(_context);
                }
                return _liquidPipelineSizeBoundaryRepository;
            }
        }

        public IFlowlineBoundaryRepository FlowlineBoundaryRepository
        {
            get
            {

                if (this._flowlineBoundaryRepository == null)
                {
                    this._flowlineBoundaryRepository = new FlowlineBoundaryRepository(_context);
                }
                return _flowlineBoundaryRepository;
            }
        }

        public IPipelineSizeCalcRepository PipelineSizeCalcRepository
        {
            get
            {

                if (this._pipelineSizeCalcRepository == null)
                {
                    this._pipelineSizeCalcRepository = new PipelineSizeCalcRepository(_context);
                }
                return _pipelineSizeCalcRepository;
            }
        }

        public IBrainTreeTypeRepository BrainTreeTypeRepository
        {
            get
            {
                if(this._brainTreeTypeRepository == null)
                {
                    this._brainTreeTypeRepository = new BrainTreeTypeRepository(_context);
                }
                return _brainTreeTypeRepository;
            }

        }
        public IBrainWaterDisposalRepository BrainWaterDisposalRepository
        {
            get
            {
                if (this._brainWaterDisposalRepository == null)
                {
                    this._brainWaterDisposalRepository = new BrainWaterDisposalRepository(_context);
                }
                return _brainWaterDisposalRepository;
            }

        }
        public IBrainPWTInjectionRepository BrainPWTInjectionRepository
        {
            get
            {
                if (this._brainPwtInjectionRepository == null)
                {
                    this._brainPwtInjectionRepository = new BrainPWTInjectionRepository(_context);
                }
                return _brainPwtInjectionRepository;
            }

        }
        public IBrainExternalWaterInjectionRepository BrainExternalWaterInjectionRepository
        {
            get
            {
                if (this._brainExternalWaterInjectionRepository == null)
                {
                    this._brainExternalWaterInjectionRepository = new BrainExternalWaterInjectionRepository(_context);
                }
                return _brainExternalWaterInjectionRepository;
            }

        }
        public IEquipmentRepository EquimentRepository
        {
            get
            {
                if(this._equimentRepository == null)
                {
                    this._equimentRepository = new EquimentRepository(_context);
                }
                return _equimentRepository;
            }
        }

        public ILookupGenericWeightEstimateRepository LookupGenericWeightEstimateRepository
        {
            get
            {
                if (this._weightEstimateRepositry == null)
                {
                    this._weightEstimateRepositry = new LookupGenericWeightEstimateRepository(_context);
                }
                return _weightEstimateRepositry;
            }
        }

        public IEquipmentMasterRepository EquipmentMasterRepository
        {
            get
            {
                if (this._equipmentMasterRepository == null)
                {
                    this._equipmentMasterRepository = new EquimentMasterRepository(_context);
                }
                return _equipmentMasterRepository;
            }
        }
        public IBrainFieldTableMappingRepository BrainFieldTableMappingRepository
        {
            get
            {
                if (this._brainFieldTableMappingRepository == null)
                {
                    this._brainFieldTableMappingRepository = new BrainFieldTableMappingRepository(_context);
                }
                return _brainFieldTableMappingRepository;
            }

        }
        public IBrainTableColumnConfigurationRepository BrainTableColumnConfigurationRepository
        {
            get
            {
                if (this._brainTableColumnConfigurationRepository == null)
                {
                    this._brainTableColumnConfigurationRepository = new BrainTableColumnConfigurationRepository(_context);
                }
                return _brainTableColumnConfigurationRepository;
            }

        }
        public ILevelInformationRepository LevelInformationRepository
        {
            get
            {
                if (this._levelInformationRepository == null)
                {
                    this._levelInformationRepository = new LevelInformationRepository(_context);
                }
                return _levelInformationRepository;
            }
        }
        

        public IBrainOilHandlingRepository BrainOilHandlingRepository
        {
            get
            {
                if (this._brainOilHandlingRepository == null)
                {
                    this._brainOilHandlingRepository = new BrainOilHandlingRepository(_context);
                }
                return _brainOilHandlingRepository;
            }

        }

        public IBrainGasInjectionRepository BrainGasInjectionRepository
        {
            get
            {
                if (this._brainGasInjectionRepository == null)
                {
                    this._brainGasInjectionRepository = new BrainGasInjectionRepository(_context);
                }
                return _brainGasInjectionRepository;
            }

        }

        public IBrainGasExportRepository BrainGasExportRepository
        {
            get
            {
                if (this._brainGasExportRepository == null)
                {
                    this._brainGasExportRepository = new BrainGasExportRepository(_context);
                }
                return _brainGasExportRepository;
            }

        }

        public IBrainGasDisposalRepository BrainGasDisposalRepository
        {
            get
            {
                if (this._brainGasDisposalRepository == null)
                {
                    this._brainGasDisposalRepository = new BrainGasDisposalRepository(_context);
                }
                return _brainGasDisposalRepository;
            }

        }

        public IBrainGasContaminantMgmtRepository BrainGasContaminantMgmtRepository
        {
            get
            {
                if (this._brainGasContaminantMgmtRepository == null)
                {
                    this._brainGasContaminantMgmtRepository = new BrainGasContaminantMgmtRepository(_context);
                }
                return _brainGasContaminantMgmtRepository;
            }

        }

        public IBrainCondensateHandlingRepository BrainCondensateHandlingRepository
        {
            get
            {
                if (this._brainCondensateHandlingRepository == null)
                {
                    this._brainCondensateHandlingRepository = new BrainCondensateHandlingRepository(_context);
                }
                return _brainCondensateHandlingRepository;
            }

        }

        public IBrainSubstructureRepository BrainSubstructureRepository
        {
            get
            {
                if (this._brainSubstructureRepository == null)
                {
                    this._brainSubstructureRepository = new BrainSubstructureRepository(_context);
                }
                return _brainSubstructureRepository;
            }

        }

        public IBrainPressureProtectionRepository BrainPressureProtectionRepository
        {
            get
            {
                if (this._brainPressureProtectionRepository == null)
                {
                    this._brainPressureProtectionRepository = new BrainPressureProtectionRepository(_context);
                }
                return _brainPressureProtectionRepository;
            }

        }

        public IBrainAccommodationRepository BrainAccommodationRepository
        {
            get
            {
                if (this._brainAccommodationRepository == null)
                {
                    this._brainAccommodationRepository = new BrainAccommodationRepository(_context);
                }
                return _brainAccommodationRepository;
            }

        }

        public IBrainDrillingAndWorkoverStrategyRepository BrainDrillingAndWorkoverStrategyRepository
        {
            get
            {
                if (this._brainDrillingAndWorkoverStrategyRepository == null)
                {
                    this._brainDrillingAndWorkoverStrategyRepository = new BrainDrillingAndWorkoverStrategyRepository(_context);
                }
                return _brainDrillingAndWorkoverStrategyRepository;
            }

        }

        public IConceptRepository ConceptRepository
        {
            get
            {
                if (this._conceptRepository == null)
                {
                    this._conceptRepository = new ConceptRepository(_context);
                }
                return _conceptRepository;
            }

        }

        public IConceptDCDetailsRepository ConceptDCDetailsRepository
        {
            get
            {
                if (this._conceptDCDetailsRepository == null)
                {
                    this._conceptDCDetailsRepository = new ConceptDCDetailsRepository(_context);
                }
                return _conceptDCDetailsRepository;
            }

        }

        public IProjectConceptQueueRepository ProjectConceptQueueRepository
        {
            get
            {
                if (this._projectConceptQueueRepository == null)
                {
                    this._projectConceptQueueRepository = new ProjectConceptQueueRepository(_context);
                }
                return _projectConceptQueueRepository;
            }

        }

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

using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IPipelineRatingRepository PipelineRatingRepository { get; }
        public ILiquidPipelineSizeBoundaryRepository LiquidPipelineSizeBoundaryRepository { get; }
        public IFlowlineBoundaryRepository FlowlineBoundaryRepository { get; }
        public IPipelineSizeCalcRepository PipelineSizeCalcRepository { get; }
        public IBrainTreeTypeRepository BrainTreeTypeRepository { get; }
        public IBrainWaterDisposalRepository BrainWaterDisposalRepository { get; }
        public IBrainPWTInjectionRepository BrainPWTInjectionRepository { get; }
        public IBrainExternalWaterInjectionRepository BrainExternalWaterInjectionRepository { get; }
        public IBrainFieldTableMappingRepository BrainFieldTableMappingRepository { get; }
        public IBrainTableColumnConfigurationRepository BrainTableColumnConfigurationRepository { get; }
        public IBrainOilHandlingRepository BrainOilHandlingRepository { get; }
        public IBrainGasInjectionRepository BrainGasInjectionRepository { get; }
        public IBrainGasExportRepository BrainGasExportRepository { get; }
        public IBrainGasDisposalRepository BrainGasDisposalRepository { get; }
        public IBrainGasContaminantMgmtRepository BrainGasContaminantMgmtRepository { get; }
        public IBrainCondensateHandlingRepository BrainCondensateHandlingRepository { get; }
        public IBrainSubstructureRepository BrainSubstructureRepository { get; }
        public IBrainPressureProtectionRepository BrainPressureProtectionRepository { get; }
        public IBrainAccommodationRepository BrainAccommodationRepository { get; }
        public IBrainDrillingAndWorkoverStrategyRepository BrainDrillingAndWorkoverStrategyRepository { get; }
        public IProjectConceptQueueRepository ProjectConceptQueueRepository { get; }
        public IConceptRepository ConceptRepository { get; }
        public IConceptDCDetailsRepository ConceptDCDetailsRepository { get; }

        public int Commit();
        public Task<int> CommitAsync();
        public void DetachEntity<T>(T entity);
        public IEquipmentRepository EquimentRepository { get; }
        public ILookupGenericWeightEstimateRepository LookupGenericWeightEstimateRepository { get; }
        public IEquipmentMasterRepository EquipmentMasterRepository { get; }
        public ILevelInformationRepository LevelInformationRepository { get; }

    }
}

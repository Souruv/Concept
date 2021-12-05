using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Services.Interfaces
{
    public interface IEvacuationOptionService
    {
        void InsertInfrastructureCondensate(IEnumerable<EvacuationOptionCondensateDto> dataDto, Guid infrastructureId);
        void InsertInfrastructureGas(IEnumerable<EvacuationOptionGasDto> dataDto, Guid infrastructureId);
        void InsertInfrastructureOil(IEnumerable<EvacuationOptionOilDto> dataDto, Guid infrastructureId);
        void InsertInfrastructureProducedWater(IEnumerable<EvacuationOptionProducedWaterDto> dataDto, Guid infrastructureId);

    }
}

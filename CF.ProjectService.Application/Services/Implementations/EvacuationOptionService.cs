using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Services.Implementations
{
    public class EvacuationOptionService : IEvacuationOptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EvacuationOptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void InsertInfrastructureCondensate(IEnumerable<EvacuationOptionCondensateDto> dataDto, Guid infrastructureId)
        {
            if (dataDto != null)
            {
                foreach (var item in dataDto)
                {
                    var newEvaDen = new EvacuationOptionCondensate()
                    {
                        Id = Guid.NewGuid(),
                        InfrastructureDataId = infrastructureId,
                        BSW = item.BSW,
                        DistanceUnit = item.Distance.Unit,
                        DistanceValue = item.Distance.FieldValue,
                        EvacuationType = item.EvacuationType,
                        H2S = item.H2S,
                        IsBaseConcept = item.IsBaseConcept,
                        NameFacilities = item.NameFacilities,
                        PressuresOperatingUnit = item.PressuresOperating.Unit,
                        PressuresOperatingValue = item.PressuresOperating.FieldValue,
                        PressuresRatedValue = item.PressuresRated.FieldValue,
                        PressuresRatedUnit = item.PressuresRated.Unit,
                        Salt = item.Salt,
                        VapourPressure = item.VapourPressure
                    };

                    _unitOfWork.EvacuationOptionCondensateRepository.Insert(newEvaDen);
                }
            }
        }

        public void InsertInfrastructureGas(IEnumerable<EvacuationOptionGasDto> dataDto, Guid infrastructureId)
        {
            if (dataDto != null)
            {
                foreach (var item in dataDto)
                {
                    var newEvaGas = new EvacuationOptionGas()
                    {
                        Id = Guid.NewGuid(),
                        Co2 = item.Co2,
                        H2S = item.H2S,
                        HydrocarbonDewpoints = item.HydrocarbonDewpoints,
                        Mercury = item.Mercury,
                        RSH = item.RSH,
                        WaterContent = item.WaterContent,
                        WaterDewpoints = item.WaterDewpoints,
                        InfrastructureDataId = infrastructureId,
                        DistanceUnit = item.Distance.Unit,
                        DistanceValue = item.Distance.FieldValue,
                        EvacuationType = item.EvacuationType,
                        IsBaseConcept = item.IsBaseConcept,
                        NameFacilities = item.NameFacilities,
                        PressuresOperatingUnit = item.PressuresOperating.Unit,
                        PressuresOperatingValue = item.PressuresOperating.FieldValue,
                        PressuresRatedUnit = item.PressuresRated.Unit,
                        PressuresRatedValue = item.PressuresRated.FieldValue,
                    };

                    _unitOfWork.EvacuationOptionGasRepository.Insert(newEvaGas);
                }
            }
        }

        public void InsertInfrastructureOil(IEnumerable<EvacuationOptionOilDto> dataDto, Guid infrastructureId)
        {
            if (dataDto != null)
            {
                foreach (var item in dataDto)
                {
                    var newEvaOil = new EvacuationOptionOil()
                    {
                        Id = Guid.NewGuid(),
                        BSW = item.BSW,
                        Salt = item.Salt,
                        VapourPressure = item.VapourPressure,
                        H2S = item.H2S,
                        InfrastructureDataId = infrastructureId,
                        DistanceUnit = item.Distance.Unit,
                        DistanceValue = item.Distance.FieldValue,
                        EvacuationType = item.EvacuationType,
                        IsBaseConcept = item.IsBaseConcept,
                        NameFacilities = item.NameFacilities,
                        PressuresOperatingUnit = item.PressuresOperating.Unit,
                        PressuresOperatingValue = item.PressuresOperating.FieldValue,
                        PressuresRatedUnit = item.PressuresRated.Unit,
                        PressuresRatedValue = item.PressuresRated.FieldValue,
                    };

                    _unitOfWork.EvacuationOptionOilRepository.Insert(newEvaOil);
                }
            }
        }

        public void InsertInfrastructureProducedWater(IEnumerable<EvacuationOptionProducedWaterDto> dataDto, Guid infrastructureId)
        {
            if (dataDto != null)
            {
                foreach (var item in dataDto)
                {
                    var newEvaProW = new EvacuationOptionProducedWater()
                    {
                        Id = Guid.NewGuid(),
                        InfrastructureDataId = infrastructureId,
                        DistanceUnit = item.Distance.Unit,
                        DistanceValue = item.Distance.FieldValue,
                        EvacuationType = item.EvacuationType,
                        IsBaseConcept = item.IsBaseConcept,
                        OilInWater = item.OilInWater
                    };

                    _unitOfWork.EvacuationOptionProducedWaterRepository.Insert(newEvaProW);
                }
            }
        }
    }
}

using CF.ProjectService.Application.Common.Extensions;
using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class InfrastructureDto : IMapFrom<InfrastructureData>
    {
        public List<EvacuationOptionCondensateDto> EvacuationOptionsCondensate { get; set; }
        public List<EvacuationOptionGasDto> EvacuationOptionsGas { get; set; }
        public List<EvacuationOptionOilDto> EvacuationOptionsOil { get; set; }
        public List<EvacuationOptionProducedWaterDto> EvacuationOptionsProducedWater { get; set; }

        public bool CheckChange(InfrastructureData infra)
        {
            if (this.EvacuationOptionsCondensate != null
                && (this.EvacuationOptionsCondensate.Any(x => x.Id == null || x.Id == Guid.Empty)
                || infra.EvacuationOptionCondensates.Count() != this.EvacuationOptionsCondensate.Count()))
            {
                return true;
            }

            if (this.EvacuationOptionsGas != null
                && (this.EvacuationOptionsGas.Any(x => x.Id == null || x.Id == Guid.Empty)
                || infra.EvacuationOptionGas.Count() != this.EvacuationOptionsCondensate.Count()))
            {
                return true;
            }

            if (this.EvacuationOptionsOil != null
                && (this.EvacuationOptionsOil.Any(x => x.Id == null || x.Id == Guid.Empty)
                || infra.EvacuationOptionOils.Count() != this.EvacuationOptionsCondensate.Count()))
            {
                return true;
            }

            if (this.EvacuationOptionsProducedWater != null
                && (this.EvacuationOptionsProducedWater.Any(x => x.Id == null || x.Id == Guid.Empty)
                || infra.EvacuationOptionProducedWaters.Count() != this.EvacuationOptionsCondensate.Count()))
            {
                return true;
            }

            // check change list Evacuation Condensate
            foreach (var conDen in this.EvacuationOptionsCondensate)
            {
                if (conDen.CheckChange(infra.EvacuationOptionCondensates.Where(x => x.Id == conDen.Id).FirstOrDefault()))
                {
                    return true;
                }
            }

            // check change list Evacuation Oil
            foreach (var oil in this.EvacuationOptionsOil)
            {
                if (oil.CheckChange(infra.EvacuationOptionOils.Where(x => x.Id == oil.Id).FirstOrDefault()))
                {
                    return true;
                }
            }

            // check change list Evacuation Gas
            foreach (var gas in this.EvacuationOptionsGas)
            {
                if (gas.CheckChange(infra.EvacuationOptionGas.Where(x => x.Id == gas.Id).FirstOrDefault()))
                {
                    return true;
                }
            }

            // check change list Evacuation Water
            foreach (var water in this.EvacuationOptionsProducedWater)
            {
                if (water.CheckChange(infra.EvacuationOptionProducedWaters.Where(x => x.Id == water.Id).FirstOrDefault()))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidationSaveChange()
        {
            // check change list Evacuation Condensate
            foreach (var conDen in this.EvacuationOptionsCondensate)
            {
                if (!conDen.ValidationSaveChange())
                {
                    return false;
                }
            }

            // check change list Evacuation Oil
            foreach (var oil in this.EvacuationOptionsOil)
            {
                if (!oil.ValidationSaveChange())
                {
                    return false;
                }
            }

            // check change list Evacuation Gas
            foreach (var gas in this.EvacuationOptionsGas)
            {
                if (!gas.ValidationSaveChange())
                {
                    return false;
                }
            }

            // check change list Evacuation Water
            foreach (var water in this.EvacuationOptionsProducedWater)
            {
                if (!water.ValidationSaveChange())
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class DistanceOption
    {
        public decimal? FieldValue { get; set; }
        public string Unit { get; set; }
        public bool CheckChange<T>(T fromDb)
        {
            return Extensions.HasChangedDifferentProperty<DistanceOption, T>(
                this,
                fromDb,
                nameof(this.FieldValue),
                "DistanceValue"
            ) || Extensions.HasChangedDifferentProperty<DistanceOption, T>(
                this,
                fromDb,
                nameof(this.Unit),
                "DistanceUnit"
            );
        }
    }

    public class PressuresOption
    {
        public decimal? FieldValue { get; set; }
        public string Unit { get; set; }
        public bool CheckChangeOperating<T>(T fromDb)
        {
            return Extensions.HasChangedDifferentProperty<PressuresOption, T>(
                this,
                fromDb,
                nameof(this.FieldValue),
                "PressuresOperatingValue"
            ) || Extensions.HasChangedDifferentProperty<PressuresOption, T>(
                this,
                fromDb,
                nameof(this.Unit),
                "PressuresOperatingUnit"
            );
        }

        public bool CheckChangeRated<T>(T fromDb)
        {
            return Extensions.HasChangedDifferentProperty<PressuresOption, T>(
                this,
                fromDb,
                nameof(this.FieldValue),
                "PressuresRatedValue"
            ) || Extensions.HasChangedDifferentProperty<PressuresOption, T>(
                this,
                fromDb,
                nameof(this.Unit),
                "PressuresRatedUnit"
            );
        }
    }

    public abstract class EvacuationOptionBaseDto<TDto, TEntity> where TDto : class where TEntity : class
    {
        public DistanceOption Distance { get; set; }
        public PressuresOption PressuresOperating { get; set; }
        public PressuresOption PressuresRated { get; set; }
        public string EvacuationType { get; set; }
        public bool IsBaseConcept { get; set; }
        public bool CheckChange(TEntity fromDb)
        {
            return fromDb == null ? true : Extensions.HasChangedAllSameProperties<EvacuationOptionBaseDto<TDto, TEntity>, TEntity>(this, fromDb)
                || this.Distance.CheckChange<TEntity>(fromDb)
                || this.PressuresOperating.CheckChangeOperating<TEntity>(fromDb)
                || this.PressuresRated.CheckChangeRated<TEntity>(fromDb);
        }

        public bool ValidationSaveChange()
        {
            if (Extensions.CheckAnyNullAllProperties(this.Distance)
                || Extensions.CheckAnyNullAllProperties(this.PressuresOperating)
                || Extensions.CheckAnyNullAllProperties(this.PressuresRated))
            {
                return false;
            }

            if (Extensions.CheckAnyNullAllProperties(this))
            {
                return false;
            }

            return true;
        }
    }

    public class EvacuationOptionCondensateDto
        : EvacuationOptionBaseDto<EvacuationOptionCondensateDto, EvacuationOptionCondensate>,
        IMapFrom<EvacuationOptionCondensate>
    {
        public Guid Id { get; set; }
        public decimal? BSW { get; set; }
        public decimal? H2S { get; set; }
        public string NameFacilities { get; set; }
        public decimal? Salt { get; set; }
        public decimal? VapourPressure { get; set; }
    }

    public class EvacuationOptionGasDto
        : EvacuationOptionBaseDto<EvacuationOptionGasDto, EvacuationOptionGas>,
        IMapFrom<EvacuationOptionGas>
    {
        public Guid Id { get; set; }
        public decimal? Co2 { get; set; }
        public decimal? H2S { get; set; }
        public decimal? HydrocarbonDewpoints { get; set; }
        public decimal? Mercury { get; set; }
        public decimal? RSH { get; set; }
        public decimal? WaterContent { get; set; }
        public decimal? WaterDewpoints { get; set; }
        public string NameFacilities { get; set; }
    }

    public class EvacuationOptionOilDto
        : EvacuationOptionBaseDto<EvacuationOptionOilDto, EvacuationOptionOil>,
        IMapFrom<EvacuationOptionOil>
    {
        public Guid Id { get; set; }
        public decimal? BSW { get; set; }
        public decimal? H2S { get; set; }
        public string NameFacilities { get; set; }
        public decimal? Salt { get; set; }
        public decimal? VapourPressure { get; set; }
    }

    public class EvacuationOptionProducedWaterDto : IMapFrom<EvacuationOptionProducedWater>
    {
        public Guid Id { get; set; }
        public DistanceOption Distance { get; set; }
        public string EvacuationType { get; set; }
        public bool IsBaseConcept { get; set; }
        public decimal? OilInWater { get; set; }

        public bool CheckChange(EvacuationOptionProducedWater fromDb)
        {
            return fromDb == null ? true : Extensions.HasChangedAllSameProperties<EvacuationOptionProducedWaterDto, EvacuationOptionProducedWater>(this, fromDb)
                || this.Distance.CheckChange<EvacuationOptionProducedWater>(fromDb);
        }

        public bool ValidationSaveChange()
        {
            if (Extensions.CheckAnyNullAllProperties(this))
            {
                return false;
            }

            return true;
        }
    }
}

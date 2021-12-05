using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities.Base
{
    public class BasePP : BaseEntity
    {
        public decimal? OilRateMax { get; set; }
        public decimal? OilRateMin { get; set; }

        public decimal? GasRateAGMax { get; set; }
        public decimal? GasRateAGMin { get; set; }

        public decimal? WaterRateOilMax { get; set; }
        public decimal? WaterRateOilMin { get; set; }

        public decimal? OilFTHPMax { get; set; }
        public decimal? OilFTHPMin { get; set; }

        public decimal? OilFTHTMax { get; set; }
        public decimal? OilFTHTMin { get; set; }

        public decimal? GasRateNAGMax { get; set; }
        public decimal? GasRateNAGMin { get; set; }

        public decimal? CondensateRateMax { get; set; }
        public decimal? CondensateRateMin { get; set; }

        public decimal? WaterRateGasMax { get; set; }
        public decimal? WaterRateGasMin { get; set; }

        public decimal? GasFTHPMax { get; set; }
        public decimal? GasFTHPMin { get; set; }

        public decimal? GasFTHTMax { get; set; }
        public decimal? GasFTHTMin { get; set; }

        public decimal? WaterInjectionRateMax { get; set; }
        public decimal? WaterInjectionRateMin { get; set; }

        public decimal? WaterInjectionPressureMax { get; set; }
        public decimal? WaterInjectionPressureMin { get; set; }

        public decimal? GasInjectionRateMax { get; set; }
        public decimal? GasInjectionRateMin { get; set; }

        public decimal? GasInjectionPressureMax { get; set; }
        public decimal? GasInjectionPressureMin { get; set; }

        public decimal? GasLiftRateMax { get; set; }
        public decimal? GasLiftRateMin { get; set; }

        public decimal? GasLiftPressureMax { get; set; }
        public decimal? GasLiftPressureMin { get; set; }

        public Guid DrillingCenterId { get; set; }
       // public DrillingCenterData DrillingCenter { get; set; }
    }
}

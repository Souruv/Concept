using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class DrillingCenterData : BaseEntity
    {
        public Guid ProjectRevisionId { get; set; }
        public string Name { get; set; }
        public string HydroCarbonType { get; set; }
        public string HydroCarbonTypeUnit { get; set; }
        public decimal WaterDepth { get; set; }
        public string WaterDepthUnit { get; set; }
        public string Nature { get; set; }
        public string NatureUnit { get; set; }
        public decimal CITHP { get; set; }
        public string CITHPUnit { get; set; }
        public string TieInLocation { get; set; }
        public string TieInLocationUnit { get; set; }
        public decimal Distance { get; set; }
        public string DistanceUnit { get; set; }
        public string ArtificialLiftType { get; set; }
        public string ArtificialLiftTypeUnit { get; set; }
        public decimal PowerRequirementPerWell { get; set; }
        public string PowerRequirementPerWellUnit { get; set; }
        // P10
        public int P10_OilProducerWell { get; set; }
        public int P10_GasProducerWell { get; set; }
        public int P10_WaterInjectorWell { get; set; }
        public int P10_GasInjectorWell { get; set; }
        public int P10_GasLiftWell { get; set; }
        public int P10_PumpedWell { get; set; }
        // P50
        public int P50_OilProducerWell { get; set; }
        public int P50_GasProducerWell { get; set; }
        public int P50_WaterInjectorWell { get; set; }
        public int P50_GasInjectorWell { get; set; }
        public int P50_GasLiftWell { get; set; }
        public int P50_PumpedWell { get; set; }
        // P90
        public int P90_OilProducerWell { get; set; }
        public int P90_GasProducerWell { get; set; }
        public int P90_WaterInjectorWell { get; set; }
        public int P90_GasInjectorWell { get; set; }
        public int P90_GasLiftWell { get; set; }
        public int P90_PumpedWell { get; set; }
        // Min Oil Item
        public decimal MinOil_CarbonDioxide { get; set; }
        public string MinOil_CarbonDioxideUnit { get; set; }
        public decimal MinOil_HydrogenSulphide { get; set; }
        public string MinOil_HydrogenSulphideUnit { get; set; }
        public decimal MinOil_Salt { get; set; }
        public string MinOil_SaltUnit { get; set; }
        public decimal MinOil_Mercaptan { get; set; }
        public string MinOil_MercaptanUnit { get; set; }
        public decimal MinOil_Mercury { get; set; }
        public string MinOil_MercuryUnit { get; set; }
        public decimal MinOil_WAT { get; set; }
        public string MinOil_WATUnit { get; set; }
        public string MinOil_Sand { get; set; }
        public string MinOil_SandUnit { get; set; }
        public decimal MinOil_ApiGravity { get; set; }
        public string MinOil_ApiGravityUnit { get; set; }
        // Max Oil Item
        public decimal MaxOil_CarbonDioxide { get; set; }
        public string MaxOil_CarbonDioxideUnit { get; set; }
        public decimal MaxOil_HydrogenSulphide { get; set; }
        public string MaxOil_HydrogenSulphideUnit { get; set; }
        public decimal MaxOil_Salt { get; set; }
        public string MaxOil_SaltUnit { get; set; }
        public decimal MaxOil_Mercaptan { get; set; }
        public string MaxOil_MercaptanUnit { get; set; }
        public decimal MaxOil_Mercury { get; set; }
        public string MaxOil_MercuryUnit { get; set; }
        public decimal MaxOil_WAT { get; set; }
        public string MaxOil_WATUnit { get; set; }
        public string MaxOil_Sand { get; set; }
        public string MaxOil_SandUnit { get; set; }
        public decimal MaxOil_ApiGravity { get; set; }
        public string MaxOil_ApiGravityUnit { get; set; }
        // Min Gas Item
        public string MinGas_CarbonDioxide { get; set; }
        public string MinGas_CarbonDioxideUnit { get; set; }
        public decimal MinGas_HydrogenSulphide { get; set; }
        public string MinGas_HydrogenSulphideUnit { get; set; }
        public decimal MinGas_Mercaptan { get; set; }
        public string MinGas_MercaptanUnit { get; set; }
        public decimal MinGas_Mercury { get; set; }
        public string MinGas_MercuryUnit { get; set; }
        public string MinGas_Sand { get; set; }
        public string MinGas_SandUnit { get; set; }
        // Max Gas Item
        public string MaxGas_CarbonDioxide { get; set; }
        public string MaxGas_CarbonDioxideUnit { get; set; }
        public decimal MaxGas_HydrogenSulphide { get; set; }
        public string MaxGas_HydrogenSulphideUnit { get; set; }
        public decimal MaxGas_Mercaptan { get; set; }
        public string MaxGas_MercaptanUnit { get; set; }
        public decimal MaxGas_Mercury { get; set; }
        public string MaxGas_MercuryUnit { get; set; }
        public string MaxGas_Sand { get; set; }
        public string MaxGas_SandUnit { get; set; }
        //Other data
        public string GOR { get; set; }
        public string GORUnit { get; set; }
        public string LGR { get; set; }
        public string LGRUnit { get; set; }
        public string CGR { get; set; }
        public string CGRUnit { get; set; }
        public string WellTestRequirement { get; set; }
        public string WellTestRequirementUnit { get; set; }
        public ProjectRevision ProjectRevision { get; set; }
        public CoeInputP10 CoeInputP10 { get; set; }
        public CoeInputP50 CoeInputP50 { get; set; }
        public CoeInputP90 CoeInputP90 { get; set; }
    }

}

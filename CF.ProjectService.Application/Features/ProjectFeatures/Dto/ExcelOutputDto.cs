using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ExcelRootDto
    {
        public string HydrocarbonType { get; set; }
       
        public decimal ProductionStartYear { get; set; }
        public decimal ProductionLife { get; set; }
        public decimal GasOilRatio { get; set; }
        public decimal LiquidGasRatio { get; set; }
        public decimal CondensateGasRatio { get; set; }
        public decimal WaxAppearanceTemperature { get; set; }
        public decimal APIGravity { get; set; }

        public string Location { get; set; }
        public string CoordinateLat { get; set; }
        public string CoordinateLon { get; set; }
        public int NumberofDrillingCenter { get; set; }

        public List<ExcelDcDetail> DcList { get; set; } = new List<ExcelDcDetail>();
        public List<ChartSeries> ChartsData { get; set; } = new List<ChartSeries>();

    }

    public class ChartSeries
    {
        public string Title { get; set; }

        public Dictionary<string, Dictionary<string, decimal?>> Series { get; set; } = new Dictionary<string, Dictionary<string, decimal?>>();
        //public Dictionary<string, decimal?> Values { get; set; } = new Dictionary<string, decimal?>();

        //public string SeriesName { get; set; }
        //public Dictionary<string, decimal?> Values { get; set; } = new Dictionary<string, decimal?>();
    }
    public class MinMaxType<T>
    {
        public T MinValue { get; set; }
        public T MaxValue { get; set; }
    }
    public class ExcelDcDetail
    {
       public string DcName { get; set; }
        public string Nature  { get; set; }
        public string TieInLocation { get; set; }
        public decimal? TieInLocationDistance { get; set; }
        public MinMaxType<decimal?> HcInitialProduction { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> HcProducers { get; set; } = new MinMaxType<decimal?>();
        public decimal Cithp { get; set; }
        public MinMaxType<decimal?> OilRate { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> GasRateAG { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> ProducedWaterForOilWell { get; set; }
        public MinMaxType<decimal?> Fthp { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> Ftht { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> GasRateNAG { get; set; }
        public MinMaxType<decimal?> CondensateRate { get; set; }
        public MinMaxType<decimal?> ProducedWaterForGasWell { get; set; }
        public MinMaxType<decimal?> GasFthp { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> GasFtht { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> WaterInjectionRate { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> WaterInjectionPressure { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> GasInjectionRate { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> GasInjectionPressure { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> GasLiftRate { get; set; } = new MinMaxType<decimal?>();
        public MinMaxType<decimal?> GasLiftPressure { get; set; } = new MinMaxType<decimal?>();


        public decimal? APIGravity { get; set; }


        public string ArtificialLift { get; set; }
        public MinMaxType<decimal?> GaxFlowRatePerwell { get; set; } = new MinMaxType<decimal?>();
        public decimal MaxSurfaceInjectionPressure { get; set; }


        public bool IRWI_HasValue { get; set; }
        public MinMaxType<int?> IRWI_NumberOfWells { get; set; } = new MinMaxType<int?>();
        public decimal? IRWI_SurfaceInjectionPressure { get; set; }
        public decimal? IRWI_InjectionFlowRate { get; set; }


        public bool IRGI_HasValue { get; set; }
        public MinMaxType<int?> IRGI_NumberOfWells { get; set; } = new MinMaxType<int?>();
        public decimal? IRGI_SurfaceInjectionPressure { get; set; } 
        public decimal? IRGI_InjectionFlowRate { get; set; }


        public decimal? Co2 { get; set; }

        public decimal? H2s { get; set; }
        public decimal? Mercury { get; set; } 

        public decimal? WaxAppearanceTemperature { get; set; } 
        public decimal? Mercaptan { get; set; } 
        public decimal? Salt { get; set; }
    }
}

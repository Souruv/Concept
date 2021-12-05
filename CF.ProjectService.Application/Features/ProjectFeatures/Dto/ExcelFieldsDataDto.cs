using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ExcelFieldsDataDto
    {
         [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        public string HydrocarbonType { get; set; }
        public string HydrocarbonTypeUnit { get; set; }
        public decimal ProductionStartYear { get; set; }
        public string ProductionStartYearUnit { get; set; }
        public decimal ProductionLife { get; set; }
        public string ProductionLifeUnit { get; set; }
        public string AbandonmentPressureUnit {get;set;}
        public decimal AbandonmentPressure {get;set;}

        public string AvailabilityWaterDisposalReservoir {get;set;}

        public string AvailabilityWaterDisposalReservoirUnit {get;set;}

        public decimal WaterDisposalLocation {get;set;}

        public string WaterDisposalLocationUnit {get;set;}

        public string AvailabilityNAGReservoir {get;set;}

        public string AvailabilityNAGReservoirUnit {get;set;}

        public string AvailabilityNearbyGasField {get;set;}

        public string AvailabilityNearbyGasFieldUnit {get;set;}

        public decimal AvailableAmountGasTobeSupplied {get;set;}

        public string AvailableAmountGasTobeSuppliedUnit {get;set;}

        public decimal OperatingPressure {get;set;}

        public string OperatingPressureUnit {get;set;}
        public string GasDisposalByReinjection { get; set; }
        public string LocationUnit {get;set;}

        public string Location {get;set;}

        //public string Coordinate {get;set;}
        public string CoordinateLat { get;  set; }
        public string CoordinateLon { get; set; }
        public string CoordinateUnit {get;set;}

        public decimal AmbientTemperatureMin {get;set;}

        public string AmbientTemperatureMinUnit {get;set;}

        public decimal AmbientTemperatureMax {get;set;}
        
        public string AmbientTemperatureMaxUnit {get;set;}

         public decimal SeabedTemperatureMin {get;set;}

        public string SeabedTemperatureMinUnit {get;set;}

        public decimal SeabedTemperatureMax {get;set;}
        
        public string SeabedTemperatureMaxUnit {get;set;}




        public decimal GOR { get; set; }
        public string GORUnit { get; set; }
        public decimal LGR { get; set; }
        public string LGRUnit { get; set; }
        public decimal CGR { get; set; }
        public string CGRUnit { get; set; }
        public decimal WAT { get; set; }
        public string WATUnit { get; set; }
        public decimal ApiGravity { get; set; }
        public string ApiGravityUnit { get; set; }
        public int NumberofDrillingCenter { get; set; }
        public List<ExcelDrillingCenterDto> DrillingCenter { get; set; }
       
    }
}

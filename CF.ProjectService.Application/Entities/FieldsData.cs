using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class FieldsData : BaseEntity
    {
        public Guid ProjectRevisionId { get; set; }
        public string HydrocacbornType { get; set; }
        public string HydrocacbornTypeUnit { get; set; }
        public decimal NumberOfDriliingCenter { get; set; }
        public decimal ProductStartYear { get; set; }
        public decimal ProductionLife { get; set; }
        public string ProductionLifeUnit { get; set; }
        public decimal AbandonmentPressure { get; set; }
        public string AbandonmentPressureUnit { get; set; }
        public string AvailabilityWater { get; set; }
        public decimal WaterDisposalLocation { get; set; }
        public string AvailabilityNAG { get; set; }
        public string AvailabilityNearbyField { get; set; }
        public decimal AvailableAmountOfGas { get; set; }
        public string AvailableAmountOfGasUnit { get; set; }
        public decimal OperatingPressure { get; set; }
        public string OperatingPressureUnit { get; set; }

        public string GasDisposalByReinjection { get; set; }
        
        public ProjectRevision ProjectRevision { get; set; }
    }
}

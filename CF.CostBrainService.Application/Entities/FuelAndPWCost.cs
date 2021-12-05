using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class FuelAndPWCost : BaseEntity
    {
        public string VesselType { get; set; }
        public decimal? PortableWater_MT_Day { get; set; }
        public decimal? Fuel_LTR_DAY { get; set; }

        public MasterSchedule MasterSchedule { get; set; }
        public MasterSubSchedule MasterSubSchedule { get; set; }
        public MasterProjectType MasterProjectType { get; set; }
        public Country Country { get; set; }

        public decimal? Cost { get; set; }
        public Guid? AssumptionId { get; set; }
        public Guid? MasterScheduleId { get; set; }
        public Guid? MasterSubScheduleId { get; set; }
        public Guid? MasterProjectTypeId { get; set; }
        public Guid? CountryId { get; set; }
    }
}

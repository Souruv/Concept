using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class MarineSpreadCost : BaseEntity
    {
        public string VesselType { get; set; }
        public decimal? QTYMOBDEMOB_Mob_Demob{ get; set; }
        public decimal? MOBDEMOB_Per_Rate{ get; set; }
        public decimal? DailyCharacterRate_DCR{ get; set; }
        public decimal? OperationalCost_PerDay { get; set; }
        public decimal? TotalDuration_Days { get; set; }

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

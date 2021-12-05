using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class ThirdPartyServicesSectionThreeCost : BaseEntity
    {
        public string Type { get; set; }
        public decimal? No_Of_MOB_DEMOB { get; set; }
        public decimal? Duration_Days { get; set; }
        public decimal? No_Of_Set { get; set; }
        public decimal? No_Of_Pax { get; set; }

        public MasterSchedule MasterSchedule { get; set; }
        public MasterProjectType MasterProjectType { get; set; }
        public Country Country { get; set; }

        public decimal? Cost { get; set; }
        public Guid? AssumptionId { get; set; }
        public Guid? MasterScheduleId { get; set; }
        public Guid? MasterProjectTypeId { get; set; }
        public Guid? CountryId { get; set; }
    }
}

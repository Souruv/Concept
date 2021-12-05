using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class ThirdPartyServicesSectionTwoCost : BaseEntity
    {
        public string Type { get; set; }
        public decimal? Value { get; set; }

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

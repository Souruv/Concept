using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class MaterialsCost : BaseEntity
    {
        public decimal? NoOfFlowLine { get; set; }
        public decimal? MYRFlowLine { get; set; }
        public decimal? Others { get; set; }

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

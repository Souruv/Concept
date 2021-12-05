using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class EquipmentToolsConsCost : BaseEntity
    {
        public decimal? ToolsAndEquip { get; set; }
        public decimal? Consumables { get; set; }
        public decimal? ManPowerPercentage { get; set; }

        public MasterSchedule MasterSchedule { get; set; }
        public MasterProjectType MasterProjectType { get; set; }
        public Country Country { get; set; }

        public decimal? TotalCost { get; set; }
        public Guid? AssumptionId { get; set; }
        public Guid? MasterScheduleId { get; set; }
        public Guid? MasterProjectTypeId { get; set; }
        public Guid? CountryId { get; set; }
    }
}

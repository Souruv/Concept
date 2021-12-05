using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class DefaultEquipmentToolsCons : BaseEntity
    {
        public decimal? ToolsAndEquip { get; set; }
        public decimal? Consumables { get; set; }
    }
}

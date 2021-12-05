using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class EquipmentToolsConsCostDto
    {
        public decimal? ToolsAndEquip { get; set; }
        public decimal? Consumables { get; set; }
        public decimal? ManPowerPercentage { get; set; }

        public decimal? TotalCost { get; set; }
    }
}

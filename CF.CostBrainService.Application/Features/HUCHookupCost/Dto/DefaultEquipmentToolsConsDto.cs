using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class DefaultEquipmentToolsDto : IMapFrom<DefaultEquipmentToolsCons>
    {
        public decimal? ToolsAndEquip { get; set; }
        public decimal? Consumables { get; set; }
    }
}

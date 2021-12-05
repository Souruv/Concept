using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class DefaultEquipmentManPowerPercentageDto: IMapFrom<DefaultEquipmentManPowerPercentage>
    {
        public decimal? ManPowerPercentage { get; set; }
    }
}

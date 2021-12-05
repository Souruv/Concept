using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Features.CostBrainSettings.Dto;
using System;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class HUCActivitiesDto 
    {
        public string Shedule { get; set; }
        public string HUCActivity { get; set; }
        public decimal? Cost { get; set; }
    }
}

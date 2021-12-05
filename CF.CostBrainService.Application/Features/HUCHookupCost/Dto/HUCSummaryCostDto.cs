using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Features.CostBrainSettings.Dto;
using System;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class HUCSummaryCostDto : IMapFrom<HUCSummaryCost>
    {
        public decimal? TotalCost { get; set; }
        public string MasterSchedule { get; set; }
        public string MasterProjectType { get; set; }
        public string Country { get; set; }
    }
}

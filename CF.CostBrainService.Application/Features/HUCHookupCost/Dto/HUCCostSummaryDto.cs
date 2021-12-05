using System;
using System.Collections.Generic;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class HUCCostSummaryDto 
    {
        public Guid? HUCCostSummaryId { get; set; }
        public string Country { get; set; }
        public string ProjectType { get; set; }
        public string CountryCurrency { get; set; }
        public List<HUCActivitiesDto> HUCActivities { get; set; }
        public HUCCostDto HUCCost { get; set; }
       
    }
}

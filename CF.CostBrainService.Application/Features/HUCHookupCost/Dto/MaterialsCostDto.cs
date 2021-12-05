using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class MaterialsCostDto
    {
        public decimal? NoOfFlowLine { get; set; }
        public decimal? MYRFlowLine { get; set; }
        public decimal? Others { get; set; }

        public decimal? Cost { get; set; }
    }
}

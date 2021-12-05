using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class DefaultOthersFuelAndPWDto : IMapFrom<DefaultOthersFuelAndPW>
    {
        public string VesselType { get; set; }
        public decimal? PortableWater_MT_Day { get; set; }
        public decimal? Fuel_LTR_DAY { get; set; }
    }
}

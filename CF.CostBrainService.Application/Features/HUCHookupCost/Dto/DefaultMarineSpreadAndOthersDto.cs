using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class DefaultMarineSpreadAndOthersDto : IMapFrom<DefaultMarineSpreadAndOthers>
    {
        public string VesselType { get; set; }
        public decimal? QTYMOBDEMOB_Mob_Demob{ get; set; }
        public decimal? MOBDEMOB_Per_Rate{ get; set; }
        public decimal? DailyCharacterRate_DCR{ get; set; }
        public decimal? OperationalCost_PerDay { get; set; }
        public decimal? TotalDuration_Days { get; set; }
    }
}

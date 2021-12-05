using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class DefaultThirdPartyServicesSectionThreeDto : IMapFrom<DefaultThirdPartyServicesSectionThree>
    {
        public string Type { get; set; }
        public decimal? No_Of_MOB_DEMOB { get; set; }
        public decimal? Duration_Days { get; set; }
        public decimal? No_Of_Set { get; set; }
        public decimal? No_Of_Pax { get; set; }
    }
}

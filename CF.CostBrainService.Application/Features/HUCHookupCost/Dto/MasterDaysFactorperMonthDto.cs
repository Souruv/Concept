using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class MasterDaysFactorperMonthDto : IMapFrom<MasterDaysFactorperMonth>
    {
        public int DaysFactorPerMonth { get; set; }
    }
}

using CF.CostBrainService.Application.Features.HUCHookupCost.Dto;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Services.Interfaces
{
    public interface IHUCHookupService
    {
        Task<HUCDefaultValuesDto>  GetHUCDefaultValues(string projectType, string country);
        Task<HUCCostSummaryDto> CalculateHUCCost(HUCInputValuesDto hucInputValuesDto,string filePath);
    }
}

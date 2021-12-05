using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Application.Features.CostBrainSettings.Dto
{
    public class EquipmentCostDto
    {
        public string Name { get; set; }

        public int? WBS { get; set; }
        public string Unit { get; set; }
        public EquipmentPriceDto Prices { get; set; }
    }

    public class EquipmentPriceDto : IMapFrom<EquipmentCost>
    {
        public decimal? Standard { get; set; }
        public decimal? Acid { get; set; }
        public decimal? PrimarySteel { get; set; }
        public decimal? SecondarySteel { get; set; }
        public decimal? Piping { get; set; }
        public decimal? Electrical { get; set; }
        public decimal? Instrument { get; set; }
        public decimal? Others { get; set; }
    }
}

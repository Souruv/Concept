using CF.CostBrainService.Application.Common.Mappings;
using System;

namespace CF.CostBrainService.Application.Features.TICostCalculation.Dto
{
    public class TransportationInstallationDto
    {
        public TIBreakdownDto Breakdown { get; set; }
        public TIOptimizationCostDto TIOptimizationCost { get; set; }
        public Guid ConceptDCDetailsId { get; set; }
        public string DCName { get; set; }
    }

    public class TIOptimizationCostDto : IMapFrom<Entities.TICostCalculation>
    {
        public MWBReference MWBReference { get; set; }
        public string Scope { get; set; }
        public string CostBasis { get; set; }
        public decimal? Duration { get; set; }
        public decimal? AssociatedCost { get; set; }
        public decimal? TotalOptimizationCost { get; set; }
        public decimal? AdditionalCost { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? USDEquivalent { get; set; }
    }

    public class TIBreakdownDto : IMapFrom<Entities.TICostCalculation>
    {
        public decimal ContratorPMT { get; set; }
        public decimal InstallationEngineering { get; set; }
        public decimal? TransportationSpread { get; set; }
        public decimal? MWB { get; set; }
        public decimal? Others { get; set; }
        public decimal? BreakdownGrandTotal { get; set; }
        public decimal? BreakdownUSDEquivalent { get; set; }
    }
    public class MWBReference : IMapFrom<Entities.TICostCalculation>
    {
        public decimal? MOB { get; set; }
        public decimal? DMOB { get; set; }
        public decimal? Installation { get; set; }
    }

}

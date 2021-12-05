using CF.CostBrainService.Application.Entities.Base;
using System;
using CF.CostBrainService.Application.Features.TICostCalculation.Commands.Dto;
using CF.CostBrainService.Application.Common.Mappings;

namespace CF.CostBrainService.Application.Entities
{
    public class TICostCalculation : BaseEntity, IMapFrom<TICostCalculationDto>
    {
        public Guid ConceptId { get; set; }
        public Guid ConceptDCDetailsId { get; set; }
        public string DCName { get; set; }
        public decimal? ContratorPMT { get; set; }
        public decimal? InstallationEngineering { get; set; }
        public decimal? TransportationSpread { get; set; }
        public decimal? MWB { get; set; }
        public decimal? Others { get; set; }
        public decimal? BreakdownGrandTotal { get; set; }
        public decimal? BreakdownUSDEquivalent { get; set; }
        public decimal? MOB { get; set; }
        public decimal? DMOB { get; set; }
        public decimal? Installation { get; set; }
        public string Scope { get; set; }
        public string CostBasis { get; set; }
        public decimal? Duration { get; set; }
        public decimal? AssociatedCost { get; set; }
        public decimal? TotalOptimizationCost { get; set; }
        public decimal? AdditionalCost { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? USDEquivalent { get; set; }
    }
}

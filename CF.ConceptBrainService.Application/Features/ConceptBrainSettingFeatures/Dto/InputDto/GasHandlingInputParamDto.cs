using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;


namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto
{
    public class GasHandlingInputParamDto
    {
        public string? HydrocarbonType { get; set; }
        public bool? HCDewpoint { get; set; }
        public bool? WaterContentDewpoint { get; set; }
        public decimal? AgFlowRate { get; set; }
        public decimal? GasInjectionFlowRate { get; set; }
        public string? GasInjectionPressure { get; set; }
        public decimal? GasLiftFlowRate { get; set; }
        public string? GasLiftPressure { get; set; }
        public bool? GasDisposalReInjection { get; set; }
        public bool? NAGReservoir { get; set; }
        public bool? NAGSeparateTrain { get; set; }
        public string? AdditionalNagFlowRate { get; set; }
        public string? AdditionalNagPressure { get; set; }
        public bool? NearByGasField { get; set; }
        public bool? NearByGasFieldProcessed { get; set; }
        public string? NearByGasFieldFlowRate { get; set; }
        public string? NearByGasFieldPressure { get; set; }
        public string? AdditionalGasRequired { get; set; }
        public bool? GasAvailableToExportDispose { get; set; }
        public bool? FlowrateGreaterThanGasInjectionPlusLift
        {
            get
            {
                return AgFlowRate > GasInjectionFlowRate + GasLiftFlowRate;
            }
        }
        public bool? InjectionLiftGreaterThanZero
        {
            get
            {
                return GasInjectionFlowRate + GasLiftFlowRate > 0;
            }
        }
       
    }
}

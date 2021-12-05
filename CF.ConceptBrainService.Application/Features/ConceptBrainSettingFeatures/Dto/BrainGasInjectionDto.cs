using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainGasInjectionDto : IMapFrom<BrainGasInjection>
    {
        public Guid? Id { get; set; }
        public string HydrocarbonType { get; set; }
        public bool? InjectionLiftGreaterThanZero { get; set; }
        public bool? FlowrateGreaterThanGasInjectionPlusLift { get; set; }
        public bool? NAGReservoir { get; set; }
        public bool? NAGSeparateTrain { get; set; }
        public bool? NAGPressureGreaterThanInjectionAndLiftPressure { get; set; }
        public bool? NearByGasField { get; set; }
        public bool? NearByGasFieldProcessed { get; set; }
        public bool? NearByPressureGreaterThanInectionAndLiftPressure { get; set; }
        public string GasInjection { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string Pipeline { get; set; }
    }
}

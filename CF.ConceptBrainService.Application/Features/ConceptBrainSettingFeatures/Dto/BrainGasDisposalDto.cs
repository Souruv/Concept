using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainGasDisposalDto : IMapFrom<BrainGasDisposal>
    {
        public Guid? Id { get; set; }
        public string HydrocarbonType { get; set; }
        public bool? FlowrateGreaterThanGasInjectionPlusLift { get; set; }
        public bool? GasDisposalReinjection { get; set; }
        public string GasDisposal { get; set; }
        public string Process { get; set; }
        public string Pipeline { get; set; }
    }
}

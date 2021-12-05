using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainGasDisposal : BaseEntity
    {
        public string HydrocarbonType { get; set; }
        public bool? FlowrateGreaterThanGasInjectionPlusLift { get; set; }
        public bool? GasDisposalReinjection { get; set; }
        public string GasDisposal { get; set; }
        public string Process { get; set; }
        public string Pipeline { get; set; }
    }
}

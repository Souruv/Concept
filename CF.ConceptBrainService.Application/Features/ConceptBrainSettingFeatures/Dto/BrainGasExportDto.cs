using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainGasExportDto : IMapFrom<BrainGasExport>
    {
        public Guid? Id { get; set; }
        public string HydrocarbonType { get; set; }
        public bool? FlowrateGreaterThanGasInjectionPlusLift { get; set; }
        public bool? HCDewpoint { get; set; }
        public bool? WaterContentDewpoint { get; set; }
        public string GasExport { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string Pipeline { get; set; }
    }
}

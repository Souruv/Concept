using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainCondensateHandlingDto : IMapFrom<BrainCondensateHandling>
    {
        public Guid? Id { get; set; }
        public string ProcessingScheme { get; set; }
        public string EvacuationScheme { get; set; }
        public bool? CondensateExport { get; set; }
        public bool? HcDewpoint { get; set; }
        public string CondensateProcessing { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string PipeLine { get; set; }
    }
}

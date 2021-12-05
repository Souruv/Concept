using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainOilHandlingDto : IMapFrom<BrainOilHandling>
    {
        public Guid? Id { get; set; }
        public string ProcessingScheme { get; set; }
        public string EvacuationScheme { get; set; }
        public bool? Desalting { get; set; }
        public bool? H2SRemoval { get; set; }
        public string OilProcessing { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string Pipeline { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainExternalWaterInjectionDto : IMapFrom<BrainExternalWaterInjection>
    {
        public Guid? Id { get; set; }
        public string Location { get; set; }
        public bool PwtLessThanInjection { get; set; }
        public string ExternalWaterInjection { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string Pipeline { get; set; }
    }
}

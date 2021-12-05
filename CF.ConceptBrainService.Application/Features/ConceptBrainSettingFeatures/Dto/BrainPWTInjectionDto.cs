using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;


namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainPWTInjectionDto : IMapFrom<BrainPWTInjection>
    {
        public Guid? Id { get; set; }
        public bool PWTGreaterThanZero { get; set; }
        public bool InjectionRequiredGreaterThanZero { get; set; }
        public string PwtInjection { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string Pipeline { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainPressureProtectionDto : IMapFrom<BrainPressureProtection>
    {
        public Guid? Id { get; set; }
        public float? CithpMin { get; set; }
        public bool Pressureprotection { get; set; }
    }
}

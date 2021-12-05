using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainTreeTypeDto : IMapFrom<BrainTreeType>
    {
        public Guid? Id { get; set; }
        public string? Location { get; set; }
        public int? NumberOfWell { get; set; }
        public int? WaterDepthMin { get; set; }
        public int? WaterDepthMax { get; set; }
        public string? TreeType { get; set; }
    }
}

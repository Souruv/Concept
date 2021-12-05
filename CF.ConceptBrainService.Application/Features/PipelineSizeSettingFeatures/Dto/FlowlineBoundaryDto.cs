using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Dto
{
    public class FlowlineBoundaryDto : IMapFrom<FlowlineBoundary>
    {
        public Guid? Id { get; set; }
        public string Formula { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int? FlowlineType { get; set; }
    }
}

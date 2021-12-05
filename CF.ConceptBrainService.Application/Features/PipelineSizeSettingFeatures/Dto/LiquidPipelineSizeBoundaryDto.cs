using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Dto
{
    public class LiquidPipelineSizeBoundaryDto : IMapFrom<LiquidPipelineSizeBoundary>
    {
        public Guid? Id { get; set; }
        public decimal LengthMin { get; set; }
        public decimal LengthMax { get; set; }
        public decimal FlowRateMin { get; set; }
        public decimal FlowRateMax { get; set; }
        public string PressureType { get; set; }
        public int Size { get; set; }
    }
}

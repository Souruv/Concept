using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;
using System;

namespace CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Dto
{
    public class PipelineRatingBoundaryDto : IMapFrom<PipelineRatingBoundary>
    {
        public Guid? Id { get; set; }
        public decimal PressureMin { get; set; }
        public decimal PressureMax { get; set; }
        public int Rating { get; set; }
    }
}

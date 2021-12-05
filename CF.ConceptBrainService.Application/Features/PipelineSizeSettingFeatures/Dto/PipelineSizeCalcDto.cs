using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Dto
{
    public class PipelineSizeCalcDto : IMapFrom<PipelineSizeCalc>
    {
        public Guid? Id { get; set; }
        public string Formula { get; set; }
        public string PipelineType { get; set; }
        public string PressureType { get; set; }
        public int Size { get; set; }
    }
}

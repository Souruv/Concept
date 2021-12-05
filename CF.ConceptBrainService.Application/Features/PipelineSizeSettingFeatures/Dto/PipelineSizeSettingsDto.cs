using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Dto
{
    public class PipelineSizeSettingsDto
    {
        public List<LiquidPipelineSizeBoundaryDto> LiquidPipelineSizeBoundaryDtos { get; set; }
        public List<PipelineSizeCalcDto> PipelineSizeCalcDtos { get; set; }
    }
}

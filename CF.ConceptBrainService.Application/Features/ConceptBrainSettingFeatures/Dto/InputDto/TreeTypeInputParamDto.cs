using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;


namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto
{
    public class TreeTypeInputParamDto 
    {
        public string? Location { get; set; }
        public int? NumberOfWell { get; set; }
        public int? WaterDepth { get; set; }
    }
}

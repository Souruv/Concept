using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto
{
    public class SubstructureInputParamDto
    {
        public string? Location { get; set; }
        public string? TreeType { get; set; }
        public int? NoOfConductors { get; set; }
        public int? WaterDepth { get; set; }
        public int? TopsideWeight { get; set; }
        public string? ProcessingScheme { get; set; }
    }
}

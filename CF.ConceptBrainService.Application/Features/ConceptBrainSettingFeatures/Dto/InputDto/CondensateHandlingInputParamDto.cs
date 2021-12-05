using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto
{
    public class CondensateHandlingInputParamDto
    {
        public string? ProcessingScheme { get; set; }
        public string? EvacuationScheme { get; set; }
        public bool? CondensateExport { get; set; }
        public bool? HcDewPoint { get; set; }
    }
}

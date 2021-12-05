using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto
{
    public class BrainGasContaminantMgmtInputParamDto
    {
        public string? Location { get; set; }
        public int? FeedCo2 { get; set; }
        public int? ExportCo2 { get; set; }
    }
}

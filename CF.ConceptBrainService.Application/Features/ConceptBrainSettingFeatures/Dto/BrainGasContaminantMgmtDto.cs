using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainGasContaminantMgmtDto : IMapFrom<BrainGasContaminantMgmt>
    {
        public Guid? Id { get; set; }
        public string Location { get; set; }
        public int? FeedCo2Max { get; set; }
        public int? FeedCo2Min { get; set; }
        public int? ExportCo2Max { get; set; }
        public int? ExportCo2Min { get; set; }
        public string CondensateProcessing { get; set; }
        public string Process { get; set; }
        public string PipeLine { get; set; }
    }
}

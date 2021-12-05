using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainGasContaminantMgmt : BaseEntity
    {
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

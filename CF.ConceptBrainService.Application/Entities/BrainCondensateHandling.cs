using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainCondensateHandling : BaseEntity
    {
        public string ProcessingScheme { get; set; }
        public string EvacuationScheme { get; set; }
        public bool? CondensateExport { get; set; }
        public bool? HcDewpoint { get; set; }
        public string CondensateProcessing { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string PipeLine { get; set; }
    }
}

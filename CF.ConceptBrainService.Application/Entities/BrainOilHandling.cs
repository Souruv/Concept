using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainOilHandling : BaseEntity
    {
        public string ProcessingScheme { get; set; }
        public string EvacuationScheme { get; set; }
        public bool? Desalting { get; set; }
        public bool? H2SRemoval { get; set; }
        public string OilProcessing { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string Pipeline { get; set; }
    }
}

using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class FlowlineBoundary : BaseEntity
    {
        public string Formula { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int? FlowlineType { get; set; }
    }
}

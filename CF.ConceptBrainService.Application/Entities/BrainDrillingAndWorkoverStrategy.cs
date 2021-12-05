using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainDrillingAndWorkoverStrategy : BaseEntity
    {
        public string TreeType { get; set; }
        public int? WaterDepthMin { get; set; }
        public int? WaterDepthMax { get; set; }
        public string Strategy { get; set; }
    }
}

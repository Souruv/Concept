using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;


namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainTreeType : BaseEntity
    {
        public string? Location { get; set; }
        public int? NumberOfWell { get; set; }
        public int? WaterDepthMin { get; set; }
        public int? WaterDepthMax { get; set; }
        public string? TreeType { get; set; }
    }
}

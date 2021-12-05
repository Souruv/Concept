using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainSubstructure : BaseEntity
    {
        public string Location { get; set; }
        public string TreeType { get; set; }
        public int? NoOfConductorsMax { get; set; }
        public int? NoOfConductorsMin { get; set; }
        public int? WaterDepthMax { get; set; }
        public int? WaterDepthMin { get; set; }
        public int? TopsideWeightMax { get; set; }
        public int? TopsideWeightMin { get; set; }
        public string ProcessingScheme { get; set; }
        public string SubStructureType { get; set; }
    }
}

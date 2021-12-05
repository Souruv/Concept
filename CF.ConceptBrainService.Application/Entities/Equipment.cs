using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class Equipment : BaseEntity
    {
        public int WBSId { get; set; }
        public string Manifolding { get; set; }
        public string? CostimatorCBS { get; set; }
        public string? Unit { get; set; }
        public string? Category { get; set; }
        //public IList<WeightEstimate> WeightEstimates;
    }
}

using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class TICostCalculationCompleted : BaseEntity
    {
        public Guid ConceptId { get; set; }
        public Guid ConceptDCDetailsId { get; set; }
        public string DCName { get; set; }
        public bool? IsCalculated { get; set; }
    }
}

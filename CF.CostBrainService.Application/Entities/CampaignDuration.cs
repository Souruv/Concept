using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class CampaignDuration : BaseEntity
    {
        public Guid ConceptId { get; set; }
        public Guid ConceptDCDetailsId { get; set; }
        public string DCName { get; set; }
        public string Activity { get; set; }
        public string Category { get; set; }
        public string Condition1 { get; set; }
        public string Condition2 { get; set; }
        public string Condition3 { get; set; }
        public string Condition4 { get; set; }
        public decimal? Duration_hrs { get; set; }
    }
}

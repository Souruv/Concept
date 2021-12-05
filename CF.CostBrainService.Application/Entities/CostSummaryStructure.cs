using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class CostSummaryStructure : BaseEntity
    {
        public Guid ConceptId { get; set; }
        public Guid ConceptDCDetailsId { get; set; }
        public string DCName { get; set; }
        public string Category { get; set; }
        public string Activity { get; set; }
        public decimal? LumpSum_RM { get; set; }
        public decimal? Total_RM { get; set; }
        public decimal? TotalDuration_Days { get; set; }
        public decimal? DCR_RM { get; set; }
    }
}

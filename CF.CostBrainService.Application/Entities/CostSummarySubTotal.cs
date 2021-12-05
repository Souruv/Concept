using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class CostSummarySubTotal : BaseEntity
    {
        public Guid ConceptId { get; set; }
        public Guid ConceptDCDetailsId { get; set; }
        public string DCName { get; set; }
        public string CostSummaryCategory { get; set; }
        public decimal? SubTotal { get; set; }
    }
}

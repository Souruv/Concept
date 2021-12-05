using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class PMTInstallation : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public ProjectType ProjectType { get; set; }
        public decimal? TotalPMTCost { get; set; }
    }
}

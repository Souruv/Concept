using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class DefaultMaterials : BaseEntity
    {
        public decimal? NoOfFlowLine { get; set; }
        public decimal? MYRFlowLine { get; set; }
        public decimal? Others { get; set; }
    }
}

using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class LeggedDuration : BaseEntity
    {
        public Guid LeggedId { get; set; }
        public MasterLegged MasterLegged { get; set; }
        public string Method { get; set; }
        public string Length { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public decimal? Duration { get; set; }
    }
}

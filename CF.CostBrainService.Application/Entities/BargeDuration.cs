using CF.CostBrainService.Application.Entities.Base;

namespace CF.CostBrainService.Application.Entities
{
    public class BargeDuration : BaseEntity
    {
        public string Barge { get; set; }        
        public string Type { get; set; }
        public decimal? Duration { get; set; }
    }
}

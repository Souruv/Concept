using CF.CostBrainService.Application.Entities.Base;

namespace CF.CostBrainService.Application.Entities
{
    public class Equipment : BaseEntity
    {
        public int WBSId { get; set; }
        public string Manifolding { get; set; }
        public string? CostimatorCBS { get; set; }
        public string? Unit { get; set; }
        public string? Category { get; set; }
    }
}

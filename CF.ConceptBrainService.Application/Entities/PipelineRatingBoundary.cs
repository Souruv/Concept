using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class PipelineRatingBoundary : BaseEntity
    {
        public decimal PressureMin { get; set; }
        public decimal PressureMax { get; set; }
        public int Rating { get; set; }
    }
}

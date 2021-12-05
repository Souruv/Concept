using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class LiquidPipelineSizeBoundary : BaseEntity
    {
        public decimal LengthMin { get; set; }
        public decimal LengthMax { get; set; }
        public decimal FlowRateMin { get; set; }
        public decimal FlowRateMax { get; set; }
        public string PressureType { get; set; }
        public int Size { get; set; }

    }
}

using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class PipelineSizeCalc : BaseEntity
    {
        public string Formula { get; set; }
        public string PipelineType { get; set; }
        public string PressureType { get; set; }
        public int Size { get; set; }
    }
}

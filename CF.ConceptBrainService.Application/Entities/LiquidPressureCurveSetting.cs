using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class LiquidPressureCurveSetting : BaseEntity
    {
        public int Size { get; set; }
        public string Formula { get; set; }
        public string Unit { get; set; }
    }
}

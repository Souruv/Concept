using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class LiquidPressureDifferentialCurveSetting : BaseEntity
    {
        public string Formula { get; set; }
        public int DifferentialPressureMin { get; set; }
        public int DifferentialPressureMax { get; set; }
    }
}

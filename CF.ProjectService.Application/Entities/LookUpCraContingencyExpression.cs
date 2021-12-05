using CF.ProjectService.Application.Entities.Base;

namespace CF.ProjectService.Application.Entities
{
    public class LookUpCraContingencyExpression : BaseEntity
    {
        public string Curve { get; set; }
        public string Expression { get; set; }
        public string EstimateClass { get; set; }
    }
}

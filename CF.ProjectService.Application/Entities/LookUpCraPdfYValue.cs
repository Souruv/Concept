using CF.ProjectService.Application.Entities.Base;

namespace CF.ProjectService.Application.Entities
{
    public class LookUpCraPdfYValue : BaseEntity
    {
        public int RowIndex { get; set; }
        public string Value { get; set; }
        public int PositiveAccurary { get; set; }
    }
}

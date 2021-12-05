using CF.ProjectService.Application.Entities.Base;

namespace CF.ProjectService.Application.Entities
{
    public class LookUpCraPdfXValue : BaseEntity
    {
        public int RowIndex { get; set; }
        public string Value { get; set; }
        public int PositiveAccurary { get; set; }
    }
}

using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class LookUpCraSCurveValue : BaseEntity
    {
        public int RowIndex { get; set; }
        public string Value { get; set; }
        public string Percent{ get; set; }
        public int PositiveAccurary { get; set; }
    }
}

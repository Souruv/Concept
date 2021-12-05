using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class UpstreamMetricColumn : BaseEntity
    {
        public string Name { get; set; }
        public string CFColumnName { get; set; }
        public string SPColumnName { get; set; }
        public string SPSubCategory { get; set; }
    }
}

using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.UpstreamMetricColumnFeatures.Dto
{
    public class UpstreamMetricColumnDto : IMapFrom<UpstreamMetricColumn>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CFColumnName { get; set; }
        public string SPColumnName { get; set; }
        public string SPSubCategory { get; set; }


    }
}

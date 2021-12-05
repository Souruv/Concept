using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class DeterministicValueDto
    {
       public Guid Id { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public int Score { get; set; }
        public string GuideLines { get; set; }

    }
}

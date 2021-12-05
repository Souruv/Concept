using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectDeterMinisticValuesPostDto
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
        public DeterministicValueDto DeterministicValueDto { get; set; }
    }
}

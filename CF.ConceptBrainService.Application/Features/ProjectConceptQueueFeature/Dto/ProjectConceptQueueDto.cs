using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ProjectConceptQueueFeature.Dto
{
    public class ProjectConceptQueueDto : IMapFrom<ProjectConceptQueue>
    {
        public Guid ProjectRevisionId { get; set; }
        public string ProcessingStatus { get; set; }
    }
}

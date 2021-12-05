using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class ProjectConceptQueue : BaseEntity
    {
        public Guid ProjectRevisionId { get; set; }
        public string ProcessingStatus { get; set; }
    }
}

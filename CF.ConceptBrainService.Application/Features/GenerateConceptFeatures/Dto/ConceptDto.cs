using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.GenerateConceptFeatures.Dto
{
    public class ConceptDto : IMapFrom<Concept>
    {
        public Guid RevisonId { get; set; }
        public int Counter { get; set; }
        public string ConceptName { get; set; }
        public string Location { get; set; }
        public string Plevel { get; set; }

    }
}

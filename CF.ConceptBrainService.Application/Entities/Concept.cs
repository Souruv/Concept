using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class Concept : BaseEntity
    {
        public Guid RevisonId { get; set; }
        public Guid ProjectConceptQueueId { get; set; }
        public ProjectConceptQueue ProjectConceptQueue { get; set; }
        public int Counter { get; set; }
        public string ConceptName { get; set; }
        public string Location { get; set; }
        public string Plevel { get; set; }
        public bool IsBaseConcept { get; set; }
        public bool IsBookmarked { get; set; }
        // public string Accomodation { get; set; }
    }
}

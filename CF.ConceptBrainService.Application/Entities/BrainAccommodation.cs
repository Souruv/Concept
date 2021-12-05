using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainAccommodation : BaseEntity
    {
        public string ProcessingScheme { get; set; }
        public string Location { get; set; }
        public string Accommodation { get; set; }
    }
}

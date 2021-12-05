using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainExternalWaterInjection : BaseEntity
    {
        public string Location { get; set; }
        public bool PwtLessThanInjection { get; set; }
        public string ExternalWaterInjection { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string Pipeline { get; set; }

    }
}

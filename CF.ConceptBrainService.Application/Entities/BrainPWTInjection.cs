using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainPWTInjection : BaseEntity
    {
        public bool PWTGreaterThanZero { get; set; }
        public bool InjectionRequiredGreaterThanZero { get; set; }
        public string PwtInjection { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string Pipeline { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainPressureProtection : BaseEntity
    {
        public float? CithpMin { get; set; }
        public bool Pressureprotection { get; set; }
    }
}

using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class LevelInformation : BaseEntity
    {
        public decimal SecMinCriteriaValue { get; set; }
        public decimal SecMaxCriteriaValue { get; set; }
    }
}

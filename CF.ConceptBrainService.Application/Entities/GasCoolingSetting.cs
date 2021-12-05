using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class GasCoolingSetting : BaseEntity
    {
        public decimal TempratureDiffMin { get; set; }
        public decimal TempratureDiffMax { get; set; }
        public string Description { get; set; }
        public string Formula { get; set; }
    }
}

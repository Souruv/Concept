using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class ProducedWaterSetting : BaseEntity
    {
        public decimal WaterDisposalSpecification { get; set; }
        public string Formula { get; set; }
        public decimal FlowRateMaxValue { get; set; }
    }
}

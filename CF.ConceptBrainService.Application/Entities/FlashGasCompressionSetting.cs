using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class FlashGasCompressionSetting : BaseEntity
    {
        public string Formula { get; set; }
        public int FlashGasCompressionCase { get; set; }
    }
}

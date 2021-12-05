using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class UtilityPowerSetting : BaseEntity
    {
        public int WbsId { get; set; }
        public string Formula { get; set; }
    }
}

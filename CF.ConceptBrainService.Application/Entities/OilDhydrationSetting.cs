using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class OilDhydrationSetting : BaseEntity
    {
        public int GravityMin { get; set; }
        public int GravityMax { get; set; }
        [DefaultValue("API")]
        public string GravityUnit { get; set; }
        public string Formula { get; set; }
    }
}

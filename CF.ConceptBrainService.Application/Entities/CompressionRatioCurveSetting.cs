using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class CompressionRatioCurveSetting : BaseEntity
    {
        public decimal CompressionRatioMin { get; set; }
        public decimal CompressionRatioMax { get; set; }
        [DefaultValue("BAR")]
        public string Unit { get; set; }
        public string Formula { get; set; }
        public decimal? FlowRateLimit { get; set; }
    }
}

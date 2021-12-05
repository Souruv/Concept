using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
   public class BrainDrillingAndWorkoverStrategyDto : IMapFrom<BrainDrillingAndWorkoverStrategy>
    {
        public Guid? Id { get; set; }
        public string TreeType { get; set; }
        public int? WaterDepthMin { get; set; }
        public int? WaterDepthMax { get; set; }
        public string Strategy { get; set; }
    }
}

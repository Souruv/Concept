using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
    public class BrainSubstructureDto : IMapFrom<BrainSubstructure>
    {
        public Guid? Id { get; set; }
        public string Location { get; set; }
        public string TreeType { get; set; }
        public int? NoOfConductorsMax { get; set; }
        public int? NoOfConductorsMin { get; set; }
        public int? WaterDepthMax { get; set; }
        public int? WaterDepthMin { get; set; }
        public int? TopsideWeightMax { get; set; }
        public int? TopsideWeightMin { get; set; }
        public string ProcessingScheme { get; set; }
        public string SubStructureType { get; set; }
    }
}

using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Dto
{
    public class EquipmentDto : IMapFrom<Equipment>
    {
        public int WBSId { get; set; }
        public string Manifolding { get; set; }
        public string? CostimatorCBS { get; set; }
        public string? Unit { get; set; }
        public string? Category { get; set; }
    }
}

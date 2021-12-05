using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Dto
{
    public class LevelInformationDto : IMapFrom<LevelInformation>
    {
        public decimal SecMinCriteriaValue { get; set; }
        public decimal SecMaxCriteriaValue { get; set; }
    }
}

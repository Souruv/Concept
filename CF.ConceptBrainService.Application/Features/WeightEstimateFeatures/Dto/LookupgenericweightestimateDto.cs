using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Dto
{
    public class LookupGenericWeightEstimateDto : IMapFrom<LookupGenericWeightEstimate>
    {

        public EquipmentDto Equipment { get; set; }
        public decimal MinCriteriaValue { get; set; }
        public decimal MaxCriteriaValue { get; set; }

        public string Criteria { get; set; }
        public string Formula { get; set; }
        public string Remarks { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsInsert { get; set; }

        public LevelInformationDto LevelInformation { get; set; }

    }
}

using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Dto
{
    public class EquipmentMasterDto: IMapFrom<EquipmentMaster>
    {
        public int WBSId { get; set; }
        public string EquipmentName { get; set; }

        public string CriteriaType { get; set; }
        public string LevelType { get; set; }
        public int LevelNo { get; set; }
    }
}

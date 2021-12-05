using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class LookupGenericWeightEstimate : BaseEntity
    {
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public string Formula { get; set; }
        public string Remarks { get; set; }
        public decimal MinCriteriaValue { get; set; }
        public decimal MaxCriteriaValue { get; set; }

        public string Criteria { get; set; }

        public Guid? LevelInformationId { get; set; }
        public LevelInformation LevelInformation { get; set; }
    }
}

using CF.ConceptBrainService.Application.Entities.Base;
using System.ComponentModel;

namespace CF.ConceptBrainService.Application.Entities
{
    public class EquipmentMaster : BaseEntity
    {
        public int WBSId { get; set; }
        public string EquipmentName { get; set; }

        public string CriteriaType { get; set; }
        public string LevelType { get; set; }

        [DefaultValue(1)]
        public int LevelNo { get; set; }
    }
}

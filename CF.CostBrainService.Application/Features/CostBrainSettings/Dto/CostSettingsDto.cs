using System.Collections.Generic;

namespace CF.CostBrainService.Application.Features.CostBrainSettings.Dto
{
    public class CostSettingsDto 
    {
        public string System { get; set; }

        public List<EquipmentCostDto> Equipments { get; set; }
    }
}

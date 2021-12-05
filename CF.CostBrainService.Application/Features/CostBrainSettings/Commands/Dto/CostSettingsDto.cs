using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Features.CostBrainSettings.Commands.Dto
{
    public class CostSettingsDto
    {
        public string System { get; set; }
        public List<EquipmentCostDto> Equipments { get; set; }      
    }
}

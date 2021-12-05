using System.Collections.Generic;

namespace CF.CostBrainService.Application.Features.CostBrainSettings.Commands.Dto
{
    public class FabricationSettingsDto
    {
        public string System { get; set; }
        public List<FabricationEquipment> Equipments { get; set; }
    }

    public class FabricationEquipment
    {
        public string Name { get; set; }
        public int? WBS { get; set; }
        public string Unit { get; set; }
        public FabricationDetails FabricationDetails { get; set; }
    }
    public class FabricationDetails 
    {
        public decimal? ManhoursPerMT { get; set; }
        public decimal? Manhours { get; set; }
    }
}

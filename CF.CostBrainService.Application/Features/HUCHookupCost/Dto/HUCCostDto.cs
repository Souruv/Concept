using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Features.CostBrainSettings.Dto;
using System;
using System.Collections.Generic;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class HUCCostDto
    {
        public List<HUCCosA1tDto> MAN_HOURS_COST { get; set; }

        public List<HUCCosA2tDto> EQUIPMENT_TOOLS_CONSUMABLES { get; set; }

        public List<HUCCostMaterialsDto> MATERIALS { get; set; }

        public List<MarineSpreadOthersDto> MARINE_SPREAD { get; set; }

        public List<ThirdPartyDto> THIRD_PARTY_SERVICES { get; set; }

        public List<WOWDto> CONTIGENCIES { get; set; }

    }
    public class HUCCosA1tDto 
    {
        public string Shedule { get; set; }
        public string ManHoursCost { get; set; }
        public decimal? Cost { get; set; }
        public decimal? ManHours { get; set; }
    }
    public class HUCCosA2tDto
    {
        public string Shedule { get; set; }
        public string EquimentName { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Remarks { get; set; }
    }
    public class HUCCostMaterialsDto
    {
        public string Shedule { get; set; }
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public decimal? FlowLinesQty { get; set; }
    }

    public class MarineSpreadOthersDto
    {
        public string Shedule { get; set; }
        public string MarineSpread { get; set; }
        public decimal? VesselCost { get; set; }
        public decimal? FuelPWCost { get; set; }
    }
    public class ThirdPartyDto
    {
        public string Shedule { get; set; }
        public string ThirdParty { get; set; }
        public decimal? Cost { get; set; }
    }
    public class WOWDto
    {
        public string Shedule { get; set; }
        public string Name { get; set; }
        public decimal? Remark { get; set; }
        public decimal? Cost { get; set; }
    }

}

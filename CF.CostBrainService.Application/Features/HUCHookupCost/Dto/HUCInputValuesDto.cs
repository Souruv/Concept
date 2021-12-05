using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class HUCInputValuesDto
    {
        public string MasterProjectType { get; set; }
        public string Country { get; set; }

        public List<TypicalManpowerCostDto> TypicalManpowerCost { get; set; }
        public EquipmentToolsConsCostDto EquipmentToolsConsCosts { get; set; }
        public MaterialsCostDto MaterialsCostDto { get; set; }
        public List<DefaultMarineSpreadAndOthersDto> DefaultMarineSpreadAndOthers { get; set; }
        public List<DefaultOthersFuelAndPWDto> DefaultOthersFuelAndPWD { get; set; }
        public List<DefaultThirdPartyServicesSectionOneDto> DefaultThirdPartyServicesSectionOne { get; set; }
        public DefaultThirdPartyServicesSectionTwoDto DefaultThirdPartyServicesSectionTwo { get; set; }
        public List<DefaultThirdPartyServicesSectionThreeDto> DefaultThirdPartyServicesSectionThree { get; set; }
    }
}

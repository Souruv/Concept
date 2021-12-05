using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class HUCDefaultValuesDto
    {
        public string countryCurrency { get; set; }
        public List<MasterProjectTypeDto> ProjectTypeMasters { get; set; }
        public List<MasterDaysFactorperMonthDto> MasterDaysFactorperMonth { get; set; }
        public List<MasterScheduleDto> MasterSchedules { get; set; }
        public List<MasterSubScheduleDto> MasterSubSchedules { get; set; }
        public List<MasterOffShoreAccomodationDto> MasterOffShoreAccomodations { get; set; }
        public List<DefaultManpowerDto> DefaultManpowers { get; set; }
        public List<DefaultManpowerManHrsRateDto> DefaultManpowerManHrsRate { get; set; }
        public List<DefaultEquipmentManPowerPercentageDto> DefaultEquipmentManPowerPercentage { get; set; }
        public List<DefaultMarineSpreadAndOthersDto> DefaultMarineSpreadAndOthers { get; set; }
        public List<DefaultOthersFuelAndPWDto> DefaultOthersFuelAndPW { get; set; }
        public List<DefaultThirdPartyServicesSectionOneDto> DefaultThirdPartyServicesSectionOne { get; set; }
        public List<DefaultThirdPartyServicesSectionTwoDto> DefaultThirdPartyServicesSectionTwo { get; set; }
        public List<DefaultThirdPartyServicesSectionThreeDto> DefaultThirdPartyServicesSectionThree { get; set; }
    }
}

using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Features.CostBrainSettings.Dto;
using System;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class TypicalManpowerCostDto
    {
        public decimal? DurationDays { get; set; }
        public decimal? QTY { get; set; }
        public decimal? MANHOURS { get; set; }
        public decimal? RATE { get; set; }

        public int MasterDaysFactorperMonth { get; set; }
        public string MasterOffShoreAccomodation { get; set; }
        public string MasterTypicalManpower { get; set; }
    }
}

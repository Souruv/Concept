using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class DefaultManpowerManHrsRateDto : IMapFrom<DefaultManpowerManHrsRate>
    {
        public decimal? MANHOURS { get; set; }
        public decimal? Rate { get; set; }
        public string MasterTypicalManPowers { get; set; }

        //Creating problem in complex object
        //public MasterTypicalManpowerDto MasterTypicalManpowers { get; set; }
    }
}

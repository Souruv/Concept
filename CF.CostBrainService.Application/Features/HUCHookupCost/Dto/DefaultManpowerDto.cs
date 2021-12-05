using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class DefaultManpowerDto : IMapFrom<DefaultManpower>
    {
        public decimal? Duration { get; set; }
        public decimal? Qty { get; set; }
        public string OFFSHOREACCOMODATION { get; set; }
        public string MasterTypicalManPowers { get; set; }

        //Creating problem in complex object
        //public MasterTypicalManpowerDto MasterTypicalManpowers { get; set; }
    }
}

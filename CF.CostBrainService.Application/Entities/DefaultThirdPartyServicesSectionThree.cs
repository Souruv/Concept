using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class DefaultThirdPartyServicesSectionThree : BaseEntity
    {
        public string Type { get; set; }
        public decimal? No_Of_MOB_DEMOB { get; set; }
        public decimal? Duration_Days{ get; set; }
        public decimal? No_Of_Set { get; set; }
        public decimal? No_Of_Pax { get; set; }
    }
}

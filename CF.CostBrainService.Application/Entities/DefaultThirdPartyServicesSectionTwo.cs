using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class DefaultThirdPartyServicesSectionTwo : BaseEntity
    {
        public string Type { get; set; }
        public decimal? Value { get; set; }
    }
}

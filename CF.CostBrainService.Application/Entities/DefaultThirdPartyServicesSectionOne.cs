using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class DefaultThirdPartyServicesSectionOne: BaseEntity
    {
        public Guid? CountryId { get; set; }

        public string Type { get; set; }
        public decimal? MOBANDDEMOB_RATE_RM_MOB { get; set; }
        public decimal? Equipment_Per_Set{ get; set; }
        public decimal? Technician_Per_Set { get; set; }

        public Country Country { get; set; }
    }
}

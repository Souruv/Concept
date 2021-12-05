using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class DefaultOthersFuelAndPW : BaseEntity
    {
        public Guid? CountryId { get; set; }

        public string VesselType { get; set; }
        public decimal? PortableWater_MT_Day { get; set; }
        public decimal? Fuel_LTR_DAY { get; set; }

        public Country Country { get; set; }
    }
}

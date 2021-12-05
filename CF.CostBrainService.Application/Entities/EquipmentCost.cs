using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class EquipmentCost : BaseEntity
    {
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public decimal? Standard { get; set; }
        public decimal? Acid { get; set; }
        public decimal? PrimarySteel { get; set; }
        public decimal? SecondarySteel { get; set; }
        public decimal? Piping { get; set; }
        public decimal? Electrical { get; set; }
        public decimal? Instrument { get; set; }
        public decimal? Others { get; set; }
        public Country CountryData { get; set; }
        public Guid CountryCode { get; set; }
    }
}

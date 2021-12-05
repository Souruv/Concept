using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class Fabrication : BaseEntity
    {
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public decimal? ManhoursPerMT { get; set; }
        public decimal? Manhours { get; set; }
        public Country CountryData { get; set; }
        public Guid CountryCode { get; set; }
    }
}

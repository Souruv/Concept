using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class Concept
    {
        public Guid Id { get; set; }
        public Guid EquipmentId { get; set; }
        public string? Country { get; set; }
        public string? CostType { get; set; }
        public decimal? Measurement { get; set; }
        public bool? IsCostCalculated { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}

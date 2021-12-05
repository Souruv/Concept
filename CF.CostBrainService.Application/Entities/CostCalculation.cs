using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class CostCalculation
    {
        public Guid Id { get; set; }
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public Guid ConceptId { get; set; }
        public string? Country { get; set; }
        public decimal? EquipmentCost { get; set; }
        public string? CostType { get; set; }
        public decimal? Measurement { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}

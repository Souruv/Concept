using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class GeneralSettingsDetails : BaseEntity
    {
        public Guid MasterGeneralSettingsId { get; set; }
        public MasterGeneralSettings MasterGeneralSettings { get; set; }
        public bool IsCurrency { get; set; }
        public string? CurrencyLabel { get; set; }
        public decimal? Value { get; set; }
        public string? Unit { get; set; }
        public string Type { get; set; }
        public bool IsMultipleValue { get; set; }
    }
}

using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class GeneralSettingsValues : BaseEntity
    {
        public Guid GeneralSettingsDetailsId { get; set; }
        public GeneralSettingsDetails GeneralSettingsDetails { get; set; }
        public string? Label { get; set; }
        public string? Value { get; set; }
        public bool? IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Features.GeneralSettings.Dto
{
    public class GeneralSettingDto
    {
        public Rate Rate { get; set; }
        public PreDevFeed PreDevFeed { get; set; }
        public OwnerCost OwnerCost { get; set; }
        public PhasingYears PhasingYears { get; set; }
        public DefaultCurrency DefaultCurrency { get; set; }
    }
    public class Rate
    {
        public Guid GenralSettingId { get; set; }
        public string label { get; set; }
        public bool IsCurrency { get; set; }
        public string CurrencyLabel { get; set; }
        public string Unit { get; set; }
        public decimal? Value { get; set; }
    }
    public class PreDevFeed
    {
        public Guid GenralSettingId { get; set; }
        public string label { get; set; }
        public bool IsCurrency { get; set; }
        public string CurrencyLabel { get; set; }
        public string Unit { get; set; }
        public decimal? Value { get; set; }
    }
    public class OwnerCost
    {
        public Guid GenralSettingId { get; set; }
        public string label { get; set; }
        public bool IsCurrency { get; set; }
        public string CurrencyLabel { get; set; }
        public string Unit { get; set; }
        public decimal? Value { get; set; }
    }
    public class PhasingYears
    {
        public Guid GenralSettingId { get; set; }
        public string label { get; set; }
        public bool IsCurrency { get; set; }
        public string CurrencyLabel { get; set; }
        public string Unit { get; set; }
        public decimal? Value { get; set; }
    }

    public class DefaultCurrency
    {
        public Guid GenralSettingId { get; set; }
        public string label { get; set; }
        public bool IsCurrency { get; set; }
        public string CurrencyLabel { get; set; }
        public string Unit { get; set; }
        public List<DefaultCurrencyValue> Value { get; set; }
    }

    public class DefaultCurrencyValue
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public bool? IsActive { get; set; }
    }
}

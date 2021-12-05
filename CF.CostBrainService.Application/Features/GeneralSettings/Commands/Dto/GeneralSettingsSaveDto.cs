using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Features.GeneralSettings.Commands.Dto
{
    public class GeneralSettingsSaveDto
    {
        public Rate Rate { get; set; }
        public PreDevFeed PreDevFeed { get; set; }
        public OwnerCost OwnerCost { get; set; }
        public PhasingYears PhasingYears { get; set; }
        public DefaultCurrency DefaultCurrency { get; set; }
    }

    public class DefaultCurrency
    {
        public Guid GenralSettingId { get; set; }
        public string Value { get; set; }
    }

    public class PhasingYears
    {
        public Guid GenralSettingId { get; set; }
        public decimal? Value { get; set; }
    }

    public class OwnerCost
    {
        public Guid GenralSettingId { get; set; }
        public decimal? Value { get; set; }
    }

    public class PreDevFeed
    {
        public Guid GenralSettingId { get; set; }
        public decimal? Value { get; set; }
    }

    public class Rate
    {
        public Guid GenralSettingId { get; set; }
        public decimal? Value { get; set; }
    }
}

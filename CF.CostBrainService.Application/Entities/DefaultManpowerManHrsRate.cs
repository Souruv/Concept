using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class DefaultManpowerManHrsRate : BaseEntity
    {
        public Guid? MasterTypicalManpowerId { get; set; }
        public Guid? CountryId { get; set; }

        public decimal? MANHOURs { get; set; }
        public decimal? Rate { get; set; }

        public MasterTypicalManpower TypicalManpowerMaster { get; set; }
        public Country Country { get; set; }
    }

}

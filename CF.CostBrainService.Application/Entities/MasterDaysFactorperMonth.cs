using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class MasterDaysFactorperMonth : BaseEntity
    {
        public int DaysFactorPerMonth { get; set; }

        public Guid? MasterProjectTypeId { get; set; }
        public Guid? CountryId { get; set; }

        public MasterProjectType MasterProjectType { get; set; }
        public Country Country { get; set; }
    }

}

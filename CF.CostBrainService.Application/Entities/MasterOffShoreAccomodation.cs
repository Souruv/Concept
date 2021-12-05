using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class MasterOffShoreAccomodation : BaseEntity
    {
        public Guid? MasterProjectTypeId { get; set; }
        public Guid? CountryId { get; set; }

        public string Value { get; set; }

        public MasterProjectType MasterProjectType { get; set; }
        public Country Country { get; set; }
    }
}

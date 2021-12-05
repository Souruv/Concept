using CF.CostBrainService.Application.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CF.CostBrainService.Application.Entities
{
    public class DefaultManpower: BaseEntity
    {
        public Guid? MasterTypicalManpowerId { get; set; }
        public Guid? MasterProjectTypeId { get; set; }
        public Guid? CountryId { get; set; }

        public decimal? Duration { get; set; }
        public decimal? Qty { get; set; }
        public string OFFSHOREACCOMODATION { get; set; }

        public MasterTypicalManpower MasterTypicalManpower { get; set; }
        public MasterProjectType MasterProjectType { get; set; }
        public Country Country { get; set; }
    }
}

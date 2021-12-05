using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class TypicalManpowerCost : BaseEntity
    {
        public decimal? DurationDays { get; set; }
        public decimal? QTY { get; set; }
        public decimal? MANHOURS { get; set; }
        public decimal? RATE { get; set; }
        public decimal? Cost { get; set; }

        public Guid? MasterDaysFactorperMonthId { get; set; }
        public Guid? MasterOffShoreAccomodationId { get; set; }
        public Guid? AssumptionId { get; set; }
        public Guid? MasterScheduleId { get; set; }
        public Guid? MasterProjectTypeId { get; set; }
        public Guid? MasterTypicalManpowerId { get; set; }
        public Guid? CountryId { get; set; }

        public MasterDaysFactorperMonth MasterDaysFactorperMonth { get; set; }
        public MasterSchedule MasterSchedule { get; set; }
        public MasterProjectType MasterProjectType { get; set; }
        public MasterOffShoreAccomodation MasterOffShoreAccomodation { get; set; }
        public MasterTypicalManpower MasterTypicalManpower { get; set; }
        public Country Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities.Base
{
    public class BaseEvacuationOptions : BaseEntity
    {
        public Guid InfrastructureDataId { get; set; }
        //public string NameFacilities { get; set; }
        //public string H2S { get; set; }
        //public decimal? PressuresValue { get; set; }
        //public string PressuresUnit { get; set; }
        public decimal? DistanceValue { get; set; }
        public string DistanceUnit { get; set; }
        public string EvacuationType { get; set; }
        public bool IsBaseConcept { get; set; }

        public InfrastructureData InfrastructureData { get; set; }
    }
}

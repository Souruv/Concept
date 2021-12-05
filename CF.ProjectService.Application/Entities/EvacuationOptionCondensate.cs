using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class EvacuationOptionCondensate : BaseEvacuationOptions
    {
        public decimal? BSW { get; set; }
        public decimal? H2S { get; set; }
        public string NameFacilities { get; set; }
        public decimal? Salt { get; set; }
        public decimal? VapourPressure { get; set; }
        public decimal? PressuresOperatingValue { get; set; }
        public string PressuresOperatingUnit { get; set; }
        public decimal? PressuresRatedValue { get; set; }
        public string PressuresRatedUnit { get; set; }
    }
}
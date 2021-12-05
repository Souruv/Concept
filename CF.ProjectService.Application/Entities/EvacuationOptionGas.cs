using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class EvacuationOptionGas : BaseEvacuationOptions
    {
        public decimal? Co2 { get; set; }
        public decimal? H2S { get; set; }
        public decimal? HydrocarbonDewpoints { get; set; }
        public decimal? Mercury { get; set; }
        public decimal? RSH { get; set; }
        public decimal? WaterContent { get; set; }
        public decimal? WaterDewpoints { get; set; }
        public string NameFacilities { get; set; }
        public decimal? PressuresOperatingValue { get; set; }
        public string PressuresOperatingUnit { get; set; }
        public decimal? PressuresRatedValue { get; set; }
        public string PressuresRatedUnit { get; set; }
    }
}

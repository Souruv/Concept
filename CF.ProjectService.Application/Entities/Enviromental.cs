using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
     public class Enviromental : BaseEntity
    {
         public Guid ProjectRevisionId { get; set; }

         public string Location {get;set;}

         public string CoordinateLat { get;  set; }
        public string CoordinateLon { get;  set; }

        public decimal? AmbientTemperatureMin {get;set;}
        public string AmbientTemperatureMinUnit { get; set; }

        public decimal? AmbientTemperatureMax {get;set;}
        public string AmbientTemperatureMaxUnit { get; set; }

        public decimal? SeabedTemperatureMin {get;set;}
        public string SeabedTemperatureMinUnit { get; set; }

        public decimal? SeabedTemperatureMax {get;set;}
        public string SeabedTemperatureMaxUnit { get; set; }

        public ProjectRevision ProjectRevision {get;set;}
    }
}

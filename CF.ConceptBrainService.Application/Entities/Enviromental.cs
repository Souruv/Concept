using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class Enviromental : BaseEntity
    {
        public Guid ProjectRevisionId { get; set; }
        public Guid ProjectConceptQueueId { get; set; }
        public ProjectConceptQueue ProjectConceptQueue { get; set; }

        public string Location { get; set; }

        public string CoordinateLat { get; set; }
        public string CoordinateLon { get; set; }

        public decimal? AmbientTemperatureMin { get; set; }
        public string AmbientTemperatureMinUnit { get; set; }

        public decimal? AmbientTemperatureMax { get; set; }
        public string AmbientTemperatureMaxUnit { get; set; }

        public decimal? SeabedTemperatureMin { get; set; }
        public string SeabedTemperatureMinUnit { get; set; }

        public decimal? SeabedTemperatureMax { get; set; }
        public string SeabedTemperatureMaxUnit { get; set; }

        public Guid PrjServiceId { get; set; }
    }
}

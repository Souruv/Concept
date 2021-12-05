using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.GenerateConceptFeatures.Dto
{
   public class ConceptSummaryDto
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public bool BaseConcept { get; set; }
        public bool IsBookmarked { get; set; }
        public int Duration { get; set; }
        public int Utc { get; set; }
        public int UtcPercentage { get; set; }
        public int Opex { get; set; }
        public int Capex { get; set; }

        public int OilProd { get; set; }
        public int WaterInj { get; set; }
        public int GasProd { get; set; }
        public int GasInj { get; set; }
        public int WattageMin { get; set; }
        public int WattageMax { get; set; }
        public int KbdMin { get; set; }
        public int KbdMax { get; set; }

        public string ProcessingScheme { get; set; }

        public string EvacuationScheme { get; set; }
        public string ContaminantManagement { get; set; }

        public string HostType { get; set; }
    }
}

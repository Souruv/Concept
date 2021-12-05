using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class BrainWaterDisposal : BaseEntity
    {
        public string AvailabilityOfDisposalReservoir { get; set; }
        public string Location { get; set; }
        public bool? PwtGreaterThanWif { get; set; }
        public string WaterDisposal { get; set; }
        public string ProcessText { get; set; }
        public string ProcessIds { get; set; }
        public string Pipeline { get; set; }
    }
}

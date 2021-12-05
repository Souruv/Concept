using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.GenerateConceptFeatures.Dto
{
    public class ConceptDCDetailsDto : IMapFrom<ConceptDCDetails>
    {
        public Guid ConceptId { get; set; }
        public ConceptDto Concept { get; set; }
        public string DCName { get; set; }
        public string WaterDisposalText { get; set; }
        public string WaterDisposalIds { get; set; }
        public string WaterDisposalPipeLine { get; set; }
        public string PWTInjectionProcessText { get; set; }
        public string PWTInjectionProcessIds { get; set; }
        public string PWTInjectionPipeline { get; set; }
        public string ExternalWaterInjectionProcessText { get; set; }
        public string ExternalWaterInjectionProcessIds { get; set; }
        public string ExternalWaterInjectionPipeline { get; set; }
        public string OilProcessingProcessText { get; set; }
        public string OilProcessingProcessIds { get; set; }
        public string OilProcessingPipeline { get; set; }
        public string GasExport { get; set; }
        public string GasExportProcessText { get; set; }
        public string GasExportProcessIds { get; set; }
        public string GasExportProcessPipeline { get; set; }
        public string GasInjection { get; set; }
        public string GasInjectionProcessText { get; set; }
        public string GasInjectionProcessIds { get; set; }
        public string GasInjectionPipeline { get; set; }
        public string GasDisposal { get; set; }
        public string GasDisposalProcess { get; set; }
        public string GasDisposalPipeline { get; set; }
        public string GasCondensateProcessing { get; set; }
        public string GasCondensateProcessingProcess { get; set; }
        public string GasCondensateProcessingPipeline { get; set; }
        public string CondensateProcessing { get; set; }
        public string CondensateProcessingProcess { get; set; }
        public string CondensateProcessingPipeline { get; set; }
        public string TreeType { get; set; }
        public string SubStructureType { get; set; }
        public bool PressureProtection { get; set; }
        public string DWStrategy { get; set; }
        public string Accomodation { get; set; }
    }
}

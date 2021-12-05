using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Entities.Base;

namespace CF.ConceptBrainService.Application.Entities
{
    public class ConceptDCDetails : BaseEntity
    {
        public Guid ConceptId{ get; set; }
        public Concept Concept { get; set; }
        public string DCName { get; set; }
        public string WaterDisposalText { get; set; }
        public string WaterDisposalIds {get; set;}
        public string WaterDisposalPipeLine { get; set; }
        public int? WaterDisposalPipeLineSize { get; set; }
        public string PWTInjectionProcessText { get; set; }
        public string PWTInjectionProcessIds { get; set; }
        public string PWTInjectionPipeline { get; set; }
        public int? PWTInjectionPipelineSize { get; set; }
        public string ExternalWaterInjectionProcessText { get; set; }
        public string ExternalWaterInjectionProcessIds { get; set; }
        public string ExternalWaterInjectionPipeline { get; set; }
        public int? ExternalWaterInjectionPipelineSize { get; set; }
        public string OilProcessingProcessText { get; set; }
        public string OilProcessingProcessIds { get; set; }
        public string OilProcessingPipeline { get; set; }
        public int? OilProcessingPipelineSize { get; set; }
        public string GasExport { get; set; }
        public string GasExportProcessText { get; set; }
        public string GasExportProcessIds { get; set; }
        public string GasExportProcessPipeline { get; set; }
        public int? GasExportProcessPipelineSize { get; set; }
        public string GasInjection { get; set; }
        public string GasInjectionProcessText { get; set; }
        public string GasInjectionProcessIds { get; set; }
        public string GasInjectionPipeline { get; set; }
        public int? GasInjectionPipelineSize { get; set; }
        public string GasDisposal { get; set; }
        public string GasDisposalProcess { get; set; }
        public string GasDisposalPipeline { get; set; }
        public int? GasDisposalPipelineSize { get; set; }
        public string GasCondensateProcessing { get; set; }
        public string GasCondensateProcessingProcess { get; set; }
        public string GasCondensateProcessingPipeline { get; set; }
        public int? GasCondensateProcessingPipelineSize { get; set; }
        public string CondensateProcessing { get; set; }
        public string CondensateProcessingProcess { get; set; }
        public string CondensateProcessingPipeline { get; set; }
        public int? CondensateProcessingPipelineSize { get; set; }
        public string TreeType { get; set; }
        public string SubStructureType { get; set; }
        public bool PressureProtection { get; set; }
        public string DWStrategy { get; set; }
        public string Accomodation { get; set; }
        public string ProcessingScheme { get; set; }
        public string EvacuationScheme { get; set; }
        public string WbsIdsCombined { get; set; }
        public decimal DryWeight { get; set; }
        public int NumberOfConductor { get; set; }
        public int WaterDepth { get; set; }
        public decimal ProducedWaterFlowrate { get; set; }
        public decimal GasliftFlowrate { get; set; }
        public decimal WaterInjectionFlowrate { get; set; }
        public decimal GasAGFlowrate { get; set; }
        public decimal GasNAGFlowrate { get; set; }
        public decimal GasInjectionFlowrate { get; set; }
        public decimal OilFlowrate { get; set; }
        public decimal NumberOfGasInjectorWell { get; set; }
        public string Gor { get; set; }
        public string Gorunit { get; set; }
        public string Lgr { get; set; }
        public string Lgrunit { get; set; }
        public string Cgr { get; set; }
        public string Cgrunit { get; set; }
        public string WellTestRequirement { get; set; }
        public decimal Distance { get; set; }
        public string DistanceUnit { get; set; }
        public decimal? PressuresRatedValue { get; set; }
        public string PressuresRatedUnit { get; set; }
        public string PressuresOperatingUnit { get; set; }
        public decimal? PressuresOperatingValue { get; set; }
        public string PipelineRating { get; set; }
        public int OilProd { get; set; }
        public int GasProd { get; set; }
        public int WaterInj { get; set; }
        public int GasInj { get; set; }
    }
}

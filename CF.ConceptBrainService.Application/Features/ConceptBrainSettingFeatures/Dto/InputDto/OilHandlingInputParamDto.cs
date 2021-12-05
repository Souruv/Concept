using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto
{
    public class OilHandlingInputParamDto 
    {
        public string? ProcessingScheme { get; set; }
        public string? EvacuationScheme { get; set; }
        public bool? Desalting { get; set; }
        public bool? H2SRemoval { get; set; }
    }
}

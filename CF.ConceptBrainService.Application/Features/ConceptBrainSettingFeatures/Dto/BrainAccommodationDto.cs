using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto
{
   public class BrainAccommodationDto : IMapFrom<BrainAccommodation>
    {
        public Guid? Id { get; set; }
        public string ProcessingScheme { get; set; }
        public string Location { get; set; }
        public string Accommodation { get; set; }
    }
}

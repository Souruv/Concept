using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Features.CostBrainSettings.Dto
{
    public class CountryDto : IMapFrom<Country>
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}

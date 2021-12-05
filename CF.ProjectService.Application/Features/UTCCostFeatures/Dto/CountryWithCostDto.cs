using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.UTCCostFeature.Dto
{
    public class CountryWithCost : IMapFrom<Country>
    {
        public Guid Id {get;set;}

        public string Country { get;set;}

        public decimal Value { get; set; }
        public int SortOrder{ get; set; }

    }
}

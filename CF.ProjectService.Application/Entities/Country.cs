using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class Country : BaseEntity 
    {
        public string CountryName { get; set; }
        public int SortOrder { get; set; }
        public IList<UTCCost> UTCCosts {get;set;}
    }
}

using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class UTCCost : BaseEntity
    {
        public string WaterDepthGroup {get;set;}

        public string Nature {get;set;}

        public int? WaterDepthMin {get;set;}

        public int? WaterDepthMax {get;set;}


        public Guid? CountryId {get;set;}

        public int Utc {get;set;}

        public Country Country {get;set;}
    }
}

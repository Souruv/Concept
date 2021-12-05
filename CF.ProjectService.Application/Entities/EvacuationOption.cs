using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class EvacuationOption : BaseEntity
    {
        public Guid InfrastructureDataId {get;set; }

        public string Title {get;set;}

        public int? WaterContent {get;set;}

        public int? MaxCo2 {get;set;}

        public int? MaxH2S {get;set;}

        public int? Salt {get;set;}

        public int? VapourPressure {get;set;}
        public InfrastructureData InfrastructureData {get;set;}
    }
}

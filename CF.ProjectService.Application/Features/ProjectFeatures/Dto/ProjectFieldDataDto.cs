using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectFieldDataDto
    {
         [JsonProperty(PropertyName = "id")]
        public string Id {get;set;}
        public string HydrocarbonType {get;set;}

        public string HydrocarbonTypeUnit {get;set;}

        public int ProductionStartYear {get;set;}

        public string ProductionStartYearUnit {get;set;}

        public IEnumerable<Test1> TestData {get;set;}
    }

    public class Test1
    {
        public string test1 { get; set; }
        public string test2 {get;set;}
    }
}

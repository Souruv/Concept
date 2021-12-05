using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ExcelCFPlusDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id {get;set;}
        public ExcelFieldsDataDto CoeInput { get; set; }
        public List<ExcelPPDto> P10Sheet { get; set; }

        public List<ExcelPPDto> P50Sheet {get;set;}

        public List<ExcelPPDto> P90Sheet {get;set;}
    }
    public class ExcelPPDto
    {
        public string Type { get; set; }
        public string Unit { get; set; }
        public decimal Total { get; set; }
        public List<DrillingCenter> DrillingCenter { get; set; }
    }
    public class DrillingCenter
    {
        public string Name { get; set; }
        //public string Total { get; set; }
        public List<Well> ListDataOfWell { get; set; }
    }
    public class Well
    {
        public decimal TotalOfDc { get; set; }
        public string Month { get; set; }
        public decimal Total { get; set; }
        public List<decimal> WellValue { get; set; }

    }
   
}

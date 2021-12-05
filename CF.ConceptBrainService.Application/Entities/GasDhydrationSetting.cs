using CF.ConceptBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CF.ConceptBrainService.Application.Entities
{
    public class GasDhydrationSetting : BaseEntity
    {
        public decimal GasExportSpecMin { get; set; }
        public decimal GasExportSpecMax { get; set; }
        public string Description { get; set; }
        public string Formula { get; set; }
    }
}

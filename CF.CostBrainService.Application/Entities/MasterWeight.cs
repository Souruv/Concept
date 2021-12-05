using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class MasterWeight : BaseEntity
    {
        public string Weight { get; set; }
        public int? MinWeight { get; set; }
        public int? MaxWeight { get; set; }
    }
}

using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class Country : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}

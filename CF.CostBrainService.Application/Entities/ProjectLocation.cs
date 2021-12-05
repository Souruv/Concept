using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class ProjectLocation : BaseEntity
    {
        public string Location { get; set; }
        public string Area { get; set; }
    }
}

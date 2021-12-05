using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class UnitRate : BaseEntity
    {                  
        public Guid LocationId { get; set; }
        public ProjectLocation ProjectLocation { get; set; }
        public Guid ProjectId { get; set; }
        public ProjectType ProjectType { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal? RM  { get; set; }
        public decimal? USD { get; set; }
        public decimal? RM_EQ { get; set; }
    }
}

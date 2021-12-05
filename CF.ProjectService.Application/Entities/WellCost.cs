using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class WellCost : BaseEntity
    {
        public Guid RevisionId { get; set; }
        //public decimal? Wells { get; set; }
        public decimal? P50Cost { get; set; }
        public decimal? P80Cost { get; set; }
        public decimal? P50OutputCost { get; set; }
        public decimal? P80OutputCost { get; set; }
        public decimal? Duration { get; set; }
        public string Remarks { get; set; }
        public WellCostType Type { get; set; }

        public ProjectRevision ProjectRevision { get; set; }
    }
}

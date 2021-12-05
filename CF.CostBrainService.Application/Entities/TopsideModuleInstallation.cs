using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class TopsideModuleInstallation : BaseEntity
    {
        public Guid InstallationId { get; set; }
        public Guid WeightId { get; set; }
        public MasterInstallation MasterInstallation { get; set; }
        public MasterWeight MasterWeight { get; set; }
        public decimal? Duration { get; set; }
        public int? NumberOfLeg { get; set; }
    }
}

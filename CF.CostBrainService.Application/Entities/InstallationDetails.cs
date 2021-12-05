using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class InstallationDetails : BaseEntity
    {
        public Guid InstallationId { get; set; }
        public MasterInstallation MasterInstallation { get; set; }
        public string Type { get; set; }
        public decimal? Duration { get; set; }

    }
}

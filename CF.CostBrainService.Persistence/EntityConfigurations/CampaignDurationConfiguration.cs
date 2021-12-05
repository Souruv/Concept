using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class CampaignDurationConfiguration : BaseEntityConfiguration<CampaignDuration>
    {
        public override void Configure(EntityTypeBuilder<CampaignDuration> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);        
        }
    }
}

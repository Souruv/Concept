using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class ProjectConceptQueueConfiguration : BaseEntityConfiguration<ProjectConceptQueue>
    {
        public override void Configure(EntityTypeBuilder<ProjectConceptQueue> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.ProcessingStatus).HasMaxLength(200);
        }
    }
}

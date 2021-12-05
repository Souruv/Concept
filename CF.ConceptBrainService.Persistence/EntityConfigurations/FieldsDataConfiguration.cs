using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class FieldsDataConfiguration : BaseEntityConfiguration<FieldsData>
    {
        public override void Configure(EntityTypeBuilder<FieldsData> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.ProjectConceptQueue).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ProjectConceptQueueId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class EnviromentalConfiguration : BaseEntityConfiguration<Enviromental>
    {
        public override void Configure(EntityTypeBuilder<Enviromental> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.ProjectConceptQueue).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ProjectConceptQueueId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

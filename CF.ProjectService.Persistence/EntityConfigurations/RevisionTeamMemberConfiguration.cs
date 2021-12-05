using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
   public  class RevisionTeamMemberConfiguration : BaseEntityConfiguration<RevisionTeamMember>
    {
        public override  void Configure(EntityTypeBuilder<RevisionTeamMember> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            
            entityTypeBuilder.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.Revision).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.RevisionId).OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}

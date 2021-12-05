using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainGasContaminantMgmtConfiguration : BaseEntityConfiguration<BrainGasContaminantMgmt>
    {
        public override void Configure(EntityTypeBuilder<BrainGasContaminantMgmt> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.Location).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.CondensateProcessing).HasMaxLength(200);
            entityTypeBuilder.Property(t => t.Process).HasMaxLength(500);
            entityTypeBuilder.Property(t => t.PipeLine).HasMaxLength(500);
        }
    }
}

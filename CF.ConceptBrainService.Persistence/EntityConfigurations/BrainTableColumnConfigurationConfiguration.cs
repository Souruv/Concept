using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainTableColumnConfigurationConfiguration : BaseEntityConfiguration<BrainTableColumnConfiguration>
    {
        public override void Configure(EntityTypeBuilder<BrainTableColumnConfiguration> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);


            entityTypeBuilder.Property(t => t.ColumnName).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.ColumnDataType).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.CheckOperator).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.ConceptInputDetailColumnName).HasMaxLength(50);
            entityTypeBuilder.HasOne(x => x.BrainFieldTableMapping).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.BrainFieldTableMappingId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

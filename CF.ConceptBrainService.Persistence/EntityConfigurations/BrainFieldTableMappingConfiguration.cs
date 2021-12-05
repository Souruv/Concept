using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
   public class BrainFieldTableMappingConfiguration :  BaseEntityConfiguration<BrainFieldTableMapping>
    {
        public override void Configure(EntityTypeBuilder<BrainFieldTableMapping> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.FieldName).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.TableName).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.FieldType).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.OutputColumnName).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.FieldDisplayName).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.OutputColumnDisplayName).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.ExecLevel).HasMaxLength(50);
        }
    }
}

using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    public class InstallationMethodConfiguration : BaseEntityConfiguration<InstallationMethod>
    {
        public override void Configure(EntityTypeBuilder<InstallationMethod> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.MethodName).IsRequired(true);
        }
    }
}

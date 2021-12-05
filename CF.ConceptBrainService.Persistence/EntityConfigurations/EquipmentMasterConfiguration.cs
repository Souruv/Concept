using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    class EquipmentMasterConfiguration : BaseEntityConfiguration<EquipmentMaster>
    {
        public override void Configure(EntityTypeBuilder<EquipmentMaster> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.EquipmentName).IsRequired(true);
            entityTypeBuilder.Property(t => t.WBSId).IsRequired(true);
        }
    }
}

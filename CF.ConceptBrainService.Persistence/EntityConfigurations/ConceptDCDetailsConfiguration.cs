using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class ConceptDCDetailsConfiguration : BaseEntityConfiguration<ConceptDCDetails>
    {
        public override void Configure(EntityTypeBuilder<ConceptDCDetails> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.WaterDisposalText).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.WaterDisposalIds).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.WaterDisposalPipeLine).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.PWTInjectionProcessText).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.PWTInjectionProcessIds).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.PWTInjectionPipeline).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.ExternalWaterInjectionProcessText).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.ExternalWaterInjectionProcessIds).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.ExternalWaterInjectionPipeline).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.OilProcessingProcessText).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.OilProcessingProcessIds).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.OilProcessingPipeline).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasExport).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasExportProcessText).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasExportProcessIds).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasExportProcessPipeline).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasInjection).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasInjectionProcessText).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasInjectionProcessIds).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasInjectionPipeline).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasDisposal).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasDisposalProcess).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasDisposalPipeline).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasCondensateProcessing).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasCondensateProcessingProcess).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.GasCondensateProcessingPipeline).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.CondensateProcessing).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.CondensateProcessingProcess).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.CondensateProcessingPipeline).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.TreeType).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.SubStructureType).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.DWStrategy).HasMaxLength(400);
            entityTypeBuilder.Property(t => t.ExternalWaterInjectionPipeline).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.Accomodation).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.ProcessingScheme).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.EvacuationScheme).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.WbsIdsCombined).HasMaxLength(200);
            entityTypeBuilder.Property(t => t.Gor).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.Gorunit).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.Lgr).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.Lgrunit).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.Cgr).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.Cgrunit).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.PressuresRatedUnit).HasMaxLength(200);
            entityTypeBuilder.Property(t => t.PressuresOperatingUnit).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.PipelineRating).HasMaxLength(100);
            entityTypeBuilder.HasOne(x => x.Concept).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ConceptId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

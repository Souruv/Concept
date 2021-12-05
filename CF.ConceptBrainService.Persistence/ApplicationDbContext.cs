using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Entities;
using CF.ConceptBrainService.Application.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options, ILoggedInUserService currentUserService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _loggedInUserService = currentUserService;
        }

      
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<BrainTreeType> BrainTreeType { get; set; }
        public DbSet<BrainFieldTableMapping> BrainFieldTableMapping { get; set; }
        public DbSet<BrainTableColumnConfiguration> BrainTableColumnConfiguration { get; set; }
        public DbSet<BrainPressureProtection> BrainPressureProtection { get; set; }
        public DbSet<BrainAccommodation> BrainAccommodation { get; set; }
        public DbSet<BrainDrillingAndWorkoverStrategy> BrainDrillingAndWorkoverStrategy { get; set; }
        public DbSet<BrainSubstructure> BrainSubstructure { get; set; }
        public DbSet<BrainCondensateHandling> BrainCondensateHandling { get; set; }
        public DbSet<BrainGasContaminantMgmt> BrainGasContaminantMgmt { get; set; }
        public DbSet<BrainGasExport> BrainGasExport { get; set; }
        public DbSet<BrainGasInjection> BrainGasInjection { get; set; }
        public DbSet<BrainGasDisposal> BrainGasDisposal { get; set; }
        public DbSet<BrainOilHandling> BrainOilHandling { get; set; }
        public DbSet<BrainWaterDisposal> BrainWaterDisposal { get; set; }
        public DbSet<BrainPWTInjection> BrainPWTInjection { get; set; }
        public DbSet<FieldsData> FieldsData { get; set; }
        public DbSet<Enviromental> Enviromental { get; set; }
        public DbSet<DrillingCenterData> DrillingCenterData { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<ConceptDCDetails> ConceptsDCDetails { get; set; }
        public DbSet<FlowlineBoundary> FlowlineBoundary { get; set; }
        public DbSet<LiquidPipelineSizeBoundary> LiquidPipelineSizeBoundary { get; set; }
        public DbSet<PipelineSizeCalc> PipelineSizeCalc { get; set; }
        public DbSet<PipelineRatingBoundary> PipelineRatingBoundary { get; set; }
        public DbSet<OilDhydrationSetting> OilDhydrationSetting { get; set; }
        public DbSet<OilDesaltingSetting> OilDesaltingSetting { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<LookupGenericWeightEstimate> LookupGenericWeightEstimate { get; set; }
        public DbSet<EquipmentMaster> EquipmentMaster { get; set; }
        public DbSet<LevelInformation> LevelInformation { get; set; }

        public DbSet<LiquidPressureCurveSetting> LiquidPressureCurveSetting { get; set; }
        public DbSet<LiquidPressureDifferentialCurveSetting> LiquidPressureDifferentialCurveSetting { get; set; }
        public DbSet<GasDhydrationSetting> GasDhydrationSetting { get; set; }
        public DbSet<GasCoolingSetting> GasCoolingSetting { get; set; }
        public DbSet<FlashGasCompressionSetting> FlashGasCompressionSetting { get; set; }
        public DbSet<CompressionRatioCurveSetting> CompressionRatioCurveSetting { get; set; }
        public DbSet<WaterInjectionSetting> WaterInjectionSetting { get; set; }
        public DbSet<ProjectConceptQueue> ProjectConceptQueue { get; set; }
        public DbSet<ProducedWaterSetting> ProducedWaterSetting { get; set; }
        public DbSet<UtilityPowerSetting> UtilityPowerSetting { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema("concept");
            ApplicationDbContextSeed.SeedData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder
                //.UseSqlServer("Data Source=ptsg-5cfdb01.database.windows.net;Initial Catalog=ConceptFactory;User ID=cfadm;Password=Petron@s13;");
                optionsBuilder.UseSqlServer("Data Source=ptsg-5cfdb01.database.windows.net;Initial Catalog=ConceptFactory;User ID=cfadm;Password=Petron@s13;",
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                   .MigrationsHistoryTable("__EFConceptMigrationsHistory", "concept")
                   );

            }

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedByUserId = _loggedInUserService.Id;
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.ModifiedByUserId = entry.Entity.CreatedByUserId;
                        entry.Entity.ModifiedOn = entry.Entity.CreatedOn;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedByUserId = _loggedInUserService.Id;
                        entry.Entity.ModifiedOn = DateTime.Now;
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}

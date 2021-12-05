using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Entities.Base;
using CF.ProjectService.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Persistence
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

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentCost> EquipmentCost { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<CostCalculation> CostCalculation { get; set; }
        public DbSet<Concept> Concept { get; set; }
        public DbSet<Fabrication> Fabrication { get; set; }
        public DbSet<MasterInstallation> MasterInstallation { get; set; }
        public DbSet<InstallationDetails> InstallationDetails { get; set; }
        public DbSet<MasterWeight> MasterWeight { get; set; }
        public DbSet<TopsideModuleInstallation> TopsideModuleInstallation { get; set; }
        public DbSet<ProjectLocation> ProjectLocation { get; set; }
        public DbSet<ProjectType> ProjectType { get; set; }
        public DbSet<UnitRate> UnitRate { get; set; }
        public DbSet<BargeDuration> BargeDuration { get; set; }
        public DbSet<InstallationMethod> InstallationMethod { get; set; }
        public DbSet<LeggedDuration> LeggedDuration { get; set; }
        public DbSet<MasterLegged> MasterLegged { get; set; }
        public DbSet<PMTInstallation> PMTInstallation { get; set; }
        public DbSet<CostSummaryStructure> CostSummaryStructure { get; set; }
        public DbSet<CostSummarySubTotal> CostSummarySubTotal { get; set; }
        public DbSet<CampaignDuration> CampaignDuration { get; set; }
        public DbSet<MasterGeneralSettings> MasterGeneralSettings { get; set; }
        public DbSet<GeneralSettingsDetails> GeneralSettingsDetails { get; set; }
        public DbSet<GeneralSettingsValues> GeneralSettingsValues { get; set; }
        public DbSet<TICostCalculation> TICostCalculation { get; set; }
        public DbSet<TICostCalculationCompleted> TICostCalculationCompleted { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema("cost");
            foreach (var et in modelBuilder.Model.GetEntityTypes())
            {
                et.SetSchema("cost");
            }
            ApplicationDbContextSeed.SeedData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ptsg-5cfdb01.database.windows.net;Initial Catalog=ConceptFactory;User ID=cfadm;Password=Petron@s13;",
                  b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                  .MigrationsHistoryTable("__EFCostMigrationsHistory", "cost")
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

using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Persistence
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
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAuditLog> ProjectAuditLogs { get; set; }
        public DbSet<ProjectNotification> ProjectNotifications { get; set; }
        public DbSet<ProjectRevision> ProjectRevisions { get; set; }

        public DbSet<ProjectUser> ProjectUsers { get; set; }


        public DbSet<ProjectStage> ProjectStages { get; set; }

        public DbSet<FieldsData> FieldsDatas { get; set; }
        public DbSet<InfrastructureData> InfrastructureDatas { get; set; }
        public DbSet<WellCost> WellCosts { get; set; }

        public DbSet<Enviromental> Enviromentals { get; set; }

        public DbSet<ProjectNature> ProjectNatures { get; set; }

        public DbSet<ProjectNatureDetail> ProjectNatureDetails { get; set; }

        public DbSet<UTCCost> UTCCosts { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<DrillingCenterData> DrillingCenters { get; set; }
        public DbSet<CoeInputP10> CoeInputP10 { get; set; }
        public DbSet<CoeInputP50> CoeInputP50 { get; set; }
        public DbSet<CoeInputP90> CoeInputP90 { get; set; }
        public DbSet<LookUpCraPdfYValue> LookUpCraPdfYValue { get; set; }
        public DbSet<LookUpCraSCurveValue> LookUpCraSCurveValue { get; set; }
        public DbSet<LookUpCraPdfXValue> LookUpCraPdfXValue { get; set; }
        public DbSet<LookUpCraAccuracyExpression> LookUpCraAccuracyExpression { get; set; }
        public DbSet<LookUpCraContingencyExpression> LookUpCraContingencyExpression { get; set; }
        public DbSet<ProjectDeterministicValue> ProjectDeterministicValues { get; set; }
        public DbSet<DeterministicValue> DeterministicValues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema("prj");
            foreach (var et in modelBuilder.Model.GetEntityTypes())
            {
                et.SetSchema("prj");
            }
            ApplicationDbContextSeed.SeedData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = CPP00174205C ;Initial Catalog=CFPlusDB123;Integrated Security=True");
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

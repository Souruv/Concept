using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CF.AuthService.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IConfiguration _configuration;
        public ApplicationDbContext()
        {
            

        }
        public ApplicationDbContext(DbContextOptions options, ILoggedInUserService currentUserService, IConfiguration configuration) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _loggedInUserService = currentUserService;
            _configuration = configuration;
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<FelStage> FelStages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema("auth");
            ApplicationDbContextSeed.SeedData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {               
                optionsBuilder.UseSqlServer("Data Source = CPP00174205C ;Initial Catalog=CFPlusDB123;Integrated Security=True");
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

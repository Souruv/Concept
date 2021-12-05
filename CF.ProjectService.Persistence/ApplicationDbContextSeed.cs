using CF.ProjectService.Application.Common.Constant;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    Name = "ConceptorAdmin",
                    Email = "admin",
                    UserPrincipal = "admin",
                    DepartmentName = "admin",
                    Role = 1,
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                }
                );

            modelBuilder.Entity<ProjectStage>().HasData(
                new ProjectStage()
                {
                    Id = new Guid("EAA4148F-034C-486C-B8BE-C93BACF7307F"),
                    Stage = "Pre-FEL",
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                }
                ,
                new ProjectStage()
                {
                    Id = new Guid("270A7711-E19E-4A13-9F77-352D14E57850"),
                    Stage = "FEL1",
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                },
                new ProjectStage()
                {
                    Id = new Guid("DC46E5DB-82BF-4064-897B-17FC4099B8CB"),
                    Stage = "FEL2",
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                },
                new ProjectStage()
                {
                    Id = new Guid("99E346E9-13FB-488B-A5AD-7569E443E03E"),
                    Stage = "FEL3",
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                });


             modelBuilder.Entity<ProjectNature>().HasData(
                new ProjectNature()
                {
                    Id = new Guid("fa5bb7f8-868b-4c91-a7b9-c6d343c30450"),
                    Nature = "Greenfield",
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                }
                ,
                new ProjectNature()
                {
                    Id = new Guid("fb5ab810-17fa-4511-be99-5b7bcfdf4d03"),
                    Nature = "Infill",
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                },
                new ProjectNature()
                {
                    Id = new Guid("e523a4d3-4c16-4310-8060-21b54bcdd173"),
                    Nature = "Brownfield",
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                });

            
            


           
        }
    }
}

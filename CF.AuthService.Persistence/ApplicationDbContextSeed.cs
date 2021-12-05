
using CF.AuthService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.AuthService.Persistence
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
                    IsAdmin = true,
                    RoleId = null,
                    FelStageId = null,
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                }
                ); ;


            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = new Guid("F0FF06E8-C884-4531-9E1A-64B7E14382DE"),
                    Name = "COE",
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
                    SortOrder=1,
                    ModifiedByUserId = null,
                    ModifiedOn = null,
                    DeletedByUserId = null,
                    DeletedOn = null,
                    IsDeleted = false
                }
                );
            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = new Guid("1B1F4607-0FF9-4C6B-B8C0-A6BC17F848AA"),
                   Name = "FEE TM",
                   CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                   CreatedOn = new DateTime(2020, 09, 21),
                   SortOrder = 2,
                   ModifiedByUserId = null,
                   ModifiedOn = null,
                   DeletedByUserId = null,
                   DeletedOn = null,
                   IsDeleted = false
               }
               );
            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = new Guid("4D94BD99-37B2-42FB-9526-B88DD1968F11"),
                   Name = "FEE TP",
                   CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                   CreatedOn = new DateTime(2020, 09, 21),
                   SortOrder = 3,
                   ModifiedByUserId = null,
                   ModifiedOn = null,
                   DeletedByUserId = null,
                   DeletedOn = null,
                   IsDeleted = false
               }
               );
            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = new Guid("F4124B6A-07B3-4153-BB0D-4E229538BF1D"),
                   Name = "FEE",
                   CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                   CreatedOn = new DateTime(2020, 09, 21),
                   SortOrder = 4,
                   ModifiedByUserId = null,
                   ModifiedOn = null,
                   DeletedByUserId = null,
                   DeletedOn = null,
                   IsDeleted = false
               }
               );

            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = new Guid("8C5E083E-988E-4BA8-AAC3-D6A2424DC68F"),
                   Name = "CE TP",
                   CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                   CreatedOn = new DateTime(2020, 09, 21),
                   SortOrder = 5,
                   ModifiedByUserId = null,
                   ModifiedOn = null,
                   DeletedByUserId = null,
                   DeletedOn = null,
                   IsDeleted = false
               }
               );

            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = new Guid("51799DE1-62E4-4BE7-9CAE-3CE9151979B6"),
                   Name = "CE",
                   CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                   CreatedOn = new DateTime(2020, 09, 21),
                   SortOrder = 6,
                   ModifiedByUserId = null,
                   ModifiedOn = null,
                   DeletedByUserId = null,
                   DeletedOn = null,
                   IsDeleted = false
               }
               );

            modelBuilder.Entity<FelStage>().HasData(
              new FelStage()
              {
                  Id = new Guid("EAA4148F-034C-486C-B8BE-C93BACF7307F"),
                  Name = "PRE-FEL",
                  CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                  CreatedOn = new DateTime(2020, 09, 21),
                  SortOrder=1,
                  ModifiedByUserId = null,
                  ModifiedOn = null,
                  DeletedByUserId = null,
                  DeletedOn = null,
                  IsDeleted = false
              }
              );
            modelBuilder.Entity<FelStage>().HasData(
              new FelStage()
              {
                  Id = new Guid("270A7711-E19E-4A13-9F77-352D14E57850"),
                  Name = "FEL 1",
                  CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                  CreatedOn = new DateTime(2020, 09, 21),
                  SortOrder = 2,
                  ModifiedByUserId = null,
                  ModifiedOn = null,
                  DeletedByUserId = null,
                  DeletedOn = null,
                  IsDeleted = false
              }
              );
            modelBuilder.Entity<FelStage>().HasData(
              new FelStage()
              {
                  Id = new Guid("DC46E5DB-82BF-4064-897B-17FC4099B8CB"),
                  Name = "FEL 2",
                  CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                  CreatedOn = new DateTime(2020, 09, 21),
                  SortOrder = 3,
                  ModifiedByUserId = null,
                  ModifiedOn = null,
                  DeletedByUserId = null,
                  DeletedOn = null,
                  IsDeleted = false
              }
              );
            modelBuilder.Entity<FelStage>().HasData(
              new FelStage()
              {
                  Id = new Guid("99E346E9-13FB-488B-A5AD-7569E443E03E"),
                  Name = "FEL 3",
                  CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                  CreatedOn = new DateTime(2020, 09, 21),
                  SortOrder = 4,
                  ModifiedByUserId = null,
                  ModifiedOn = null,
                  DeletedByUserId = null,
                  DeletedOn = null,
                  IsDeleted = false
              }
              );







        }
    }
}

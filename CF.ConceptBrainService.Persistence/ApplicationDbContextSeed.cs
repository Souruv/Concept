//using CF.ConceptBrainService.Application.Common.Constant;
using CF.ConceptBrainService.Application.Entities;
using CF.ConceptBrainService.Application.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence
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

            modelBuilder.Entity<EquipmentMaster>().HasData(
                new EquipmentMaster()
                {
                    Id = new Guid("05B435FD-C0F1-4168-94CE-C4F99821CFE8"),
                    CriteriaType = "Range",
                    LevelType = "Input:No of gas injection wells, 1:Pipe Rating",
                    WBSId=0,
                    EquipmentName=string.Empty,
                    CreatedByUserId = new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC"),
                    CreatedOn = new DateTime(2020, 09, 21),
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

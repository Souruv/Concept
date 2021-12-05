﻿// <auto-generated />
using System;
using CF.CostBrainService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CF.CostBrainService.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210930132938_RemoveCountryField")]
    partial class RemoveCountryField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cost")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserPrincipal")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("AppUsers", "cost");
                });

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.Concept", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CostType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsCostCalculated")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Measurement")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Concept", "cost");
                });

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.CostCalculation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConceptId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CostType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("EquipmentCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Measurement")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("CostCalculation", "cost");
                });

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.Country", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Country", "cost");
                });

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostimatorCBS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Manifolding")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WBSId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Equipment", "cost");
                });

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.EquipmentCost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Acid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CountryCode")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Electrical")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Instrument")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Others")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Piping")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PrimarySteel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SecondarySteel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Standard")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("EquipmentCost", "cost");
                });

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.AppUser", b =>
                {
                    b.HasOne("CF.CostBrainService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.CostBrainService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.CostBrainService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.CostCalculation", b =>
                {
                    b.HasOne("CF.CostBrainService.Application.Entities.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.Equipment", b =>
                {
                    b.HasOne("CF.CostBrainService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.CostBrainService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.CostBrainService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("CF.CostBrainService.Application.Entities.EquipmentCost", b =>
                {
                    b.HasOne("CF.CostBrainService.Application.Entities.Country", "CountryData")
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.CostBrainService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.CostBrainService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.CostBrainService.Application.Entities.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.CostBrainService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CountryData");

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("Equipment");

                    b.Navigation("ModifiedByUser");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using CF.ConceptBrainService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210917123214_addpipelineratingtable")]
    partial class addpipelineratingtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("concept")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.AppUser", b =>
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

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentName = "admin",
                            Email = "admin",
                            IsDeleted = false,
                            Name = "ConceptorAdmin",
                            Role = 1,
                            UserPrincipal = "admin"
                        });
                });

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.BrainTreeType", b =>
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NumberOfWell")
                        .HasColumnType("int");

                    b.Property<string>("TreeType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("WaterDepthMax")
                        .HasColumnType("int");

                    b.Property<int?>("WaterDepthMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("BrainTreeType");
                });

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.LiquidPipelineSizeBoundary", b =>
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

                    b.Property<decimal>("FlowRateMax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FlowRateMin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("LengthMax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LengthMin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PressureType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("LiquidPipelineSizeBoundary");
                });

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.PipelineRatingBoundary", b =>
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PressureMax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PressureMin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("PipelineRatingBoundary");
                });

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.PipelineSizeCalc", b =>
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

                    b.Property<string>("Formula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PipelineType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PressureType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("PipelineSizeCalc");
                });

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.AppUser", b =>
                {
                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.BrainTreeType", b =>
                {
                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.LiquidPipelineSizeBoundary", b =>
                {
                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.PipelineRatingBoundary", b =>
                {
                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("CF.ConceptBrainService.Application.Entities.PipelineSizeCalc", b =>
                {
                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.ConceptBrainService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("ModifiedByUser");
                });
#pragma warning restore 612, 618
        }
    }
}

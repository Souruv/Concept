// <auto-generated />
using System;
using CF.AuthService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CF.AuthService.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210913121051_seed-data")]
    partial class seeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("auth")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CF.AuthService.Application.Entities.AppUser", b =>
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

                    b.Property<Guid?>("FelStageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

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

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserPrincipal")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("FelStageId");

                    b.HasIndex("ModifiedByUserId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentName = "admin",
                            Email = "admin",
                            IsAdmin = true,
                            IsDeleted = false,
                            Name = "ConceptorAdmin",
                            UserPrincipal = "admin"
                        });
                });

            modelBuilder.Entity("CF.AuthService.Application.Entities.FelStage", b =>
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("FelStages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bfc7d1e9-f9be-4bb6-b8ff-9dc1e0429dae"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "PRE-FEL"
                        },
                        new
                        {
                            Id = new Guid("e365b29a-18e2-4c42-a054-72ec17c7b286"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "FEL-1"
                        },
                        new
                        {
                            Id = new Guid("ee616698-2eef-460f-bc02-72f25695a6fa"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "FEL-2"
                        },
                        new
                        {
                            Id = new Guid("32965527-1fd5-4275-b567-e633da25c737"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "FEL-3"
                        });
                });

            modelBuilder.Entity("CF.AuthService.Application.Entities.Role", b =>
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03afecc4-887a-43e7-bd1e-86971fd2ccad"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "CE TM"
                        },
                        new
                        {
                            Id = new Guid("7e94e736-4b5c-416b-8a40-6a6130484f84"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "FEE TM"
                        },
                        new
                        {
                            Id = new Guid("27f828b4-5f4f-4c02-8d70-b94a1456869a"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "COE"
                        },
                        new
                        {
                            Id = new Guid("ac90d13c-2cae-4a0c-a447-7ef333492ee0"),
                            CreatedByUserId = new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"),
                            CreatedOn = new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "FEE"
                        });
                });

            modelBuilder.Entity("CF.AuthService.Application.Entities.AppUser", b =>
                {
                    b.HasOne("CF.AuthService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.AuthService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.AuthService.Application.Entities.FelStage", "FelStage")
                        .WithMany()
                        .HasForeignKey("FelStageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.AuthService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.AuthService.Application.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("FelStage");

                    b.Navigation("ModifiedByUser");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CF.AuthService.Application.Entities.FelStage", b =>
                {
                    b.HasOne("CF.AuthService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.AuthService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.AuthService.Application.Entities.AppUser", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("CF.AuthService.Application.Entities.Role", b =>
                {
                    b.HasOne("CF.AuthService.Application.Entities.AppUser", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CF.AuthService.Application.Entities.AppUser", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CF.AuthService.Application.Entities.AppUser", "ModifiedByUser")
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

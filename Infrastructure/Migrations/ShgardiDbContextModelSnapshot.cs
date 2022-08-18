﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ScrumDbContext))]
    partial class ShgardiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Core.Entities.AbsentTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DaysCount")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AbsentTypes");
                });

            modelBuilder.Entity("Core.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Name")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Core.Entities.Squad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Squads");
                });

            modelBuilder.Entity("Core.Entities.SystemConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AmazonS3CDN")
                        .HasColumnType("text");

                    b.Property<string>("FullSiteURL")
                        .HasColumnType("text");

                    b.Property<string>("TFSCollectionUrl")
                        .HasColumnType("text");

                    b.Property<string>("TFSIterationPath")
                        .HasColumnType("text");

                    b.Property<string>("TFSPAT")
                        .HasColumnType("text");

                    b.Property<string>("TFSProject")
                        .HasColumnType("text");

                    b.Property<DateTime?>("TFSScrumEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("TFSScrumStartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TFSSprintName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("Core.Entities.TFSUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Ordering")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SquadId")
                        .HasColumnType("integer");

                    b.Property<string>("TFSName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("SquadId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("TFSUsers");
                });

            modelBuilder.Entity("Core.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Name")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Core.Entities.TFSUser", b =>
                {
                    b.HasOne("Core.Entities.TFSUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Department", "Department")
                        .WithMany("TFSUsers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Squad", "Squad")
                        .WithMany("TFSUsers")
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserRole", "UserRole")
                        .WithMany("TFSUsers")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Department");

                    b.Navigation("Squad");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Core.Entities.Department", b =>
                {
                    b.Navigation("TFSUsers");
                });

            modelBuilder.Entity("Core.Entities.Squad", b =>
                {
                    b.Navigation("TFSUsers");
                });

            modelBuilder.Entity("Core.Entities.UserRole", b =>
                {
                    b.Navigation("TFSUsers");
                });
#pragma warning restore 612, 618
        }
    }
}

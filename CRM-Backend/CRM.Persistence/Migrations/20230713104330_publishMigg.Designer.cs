﻿// <auto-generated />
using System;
using CRM_Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRM_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230713104330_publishMigg")]
    partial class publishMigg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRM.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Email");

                    b.Property<int>("ExperienceYear")
                        .HasColumnType("int")
                        .HasColumnName("ExperienceYear");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName");

                    b.Property<int>("IsSentToPipedrive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("IsSentToPipedrive");

                    b.Property<string>("LandingId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("LandingId");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Phone");

                    b.Property<int>("PositionId")
                        .HasColumnType("int")
                        .HasColumnName("PositionId");

                    b.Property<int>("SectorId")
                        .HasColumnType("int")
                        .HasColumnName("SectorId");

                    b.Property<string>("University")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("University");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("SectorId");

                    b.ToTable("Customer", "dbo");
                });

            modelBuilder.Entity("CRM.Domain.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.Property<int>("Score")
                        .HasColumnType("int")
                        .HasColumnName("Score");

                    b.HasKey("Id");

                    b.ToTable("Position", "dbo");
                });

            modelBuilder.Entity("CRM.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Role", "dbo");
                });

            modelBuilder.Entity("CRM.Domain.Entities.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Group")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Group");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.Property<int>("Score")
                        .HasColumnType("int")
                        .HasColumnName("Score");

                    b.HasKey("Id");

                    b.ToTable("Sector", "dbo");
                });

            modelBuilder.Entity("CRM.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("PasswordHash");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("CRM.Domain.Entities.Customer", b =>
                {
                    b.HasOne("CRM.Domain.Entities.Position", "Position")
                        .WithMany("Customers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("position_customer_id_fk");

                    b.HasOne("CRM.Domain.Entities.Sector", "Sector")
                        .WithMany("Customers")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("sector_customer_id_fk");

                    b.Navigation("Position");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("CRM.Domain.Entities.User", b =>
                {
                    b.HasOne("CRM.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("role_user_id_fk");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CRM.Domain.Entities.Position", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("CRM.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CRM.Domain.Entities.Sector", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}

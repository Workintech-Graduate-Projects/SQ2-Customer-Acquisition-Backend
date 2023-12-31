﻿using CRM.Domain.Entities;
using CRM_Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Position> Positions { get; set; } 
        public DbSet<Sector> Sectors { get; set; }//veritabanındaki sektör tablosuna erişebilmek için oluşturulan değişken.
                                                  //Bu tablo üzerinde değişiklik yapmak için bu değişken kullanılacak

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringContants.DbConnectionString);
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }

            base.OnConfiguring(optionsBuilder);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //mapping işlemleri yapar
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(i => i.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseIdentityColumn()
                    .IsRequired();
                entity.Property(i => i.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.HasMany(i => i.Users).WithOne(i => i.Role).HasForeignKey(i => i.RoleId).HasConstraintName("role_user_id_fk");
            });
           

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(i => i.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseIdentityColumn()
                    .IsRequired();
                entity.Property(i => i.Username)
                    .HasColumnName("Username")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.PasswordHash)
                    .HasColumnName("PasswordHash")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.RoleId)
                .HasColumnName("RoleId");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(i => i.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseIdentityColumn()
                    .IsRequired();
                entity.Property(i => i.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.ExperienceYear)
                    .HasColumnName("ExperienceYear")
                    .HasColumnType("int");
                entity.Property(i => i.Email)
                    .HasColumnName("Email")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.Phone)
                    .HasColumnName("Phone")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.Age)
                    .HasColumnName("Age")
                    .HasColumnType("int");
                entity.Property(i => i.University)
                    .HasColumnName("University")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.SectorId)
                .HasColumnName("SectorId");
                entity.Property(i => i.PositionId)
                .HasColumnName("PositionId");
                entity.Property(i => i.LandingId)
                .HasColumnName("LandingId")
                .HasColumnType("varchar")
                .HasMaxLength(100);
                entity.Property(i => i.IsSentToPipedrive)
                .HasColumnName("IsSentToPipedrive")
                .HasConversion<BoolToZeroOneConverter<int>>()
                .HasDefaultValue(false);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(i => i.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseIdentityColumn()
                    .IsRequired();
                entity.Property(i => i.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.Score)
                    .HasColumnName("Score")
                    .HasColumnType("int");

                entity.HasMany(i => i.Customers).WithOne(i => i.Position).HasForeignKey(i => i.PositionId).HasConstraintName("position_customer_id_fk");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("Sector");

                entity.Property(i => i.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseIdentityColumn()
                    .IsRequired();
                entity.Property(i => i.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.Group)
                    .HasColumnName("Group")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.Score)
                    .HasColumnName("Score")
                    .HasColumnType("int");

                entity.HasMany(i => i.Customers).WithOne(i => i.Sector).HasForeignKey(i => i.SectorId).HasConstraintName("sector_customer_id_fk");
            });


            base.OnModelCreating(modelBuilder);
        }
    }


}

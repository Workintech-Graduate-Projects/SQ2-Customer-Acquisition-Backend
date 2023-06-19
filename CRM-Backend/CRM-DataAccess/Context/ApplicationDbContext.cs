﻿using CRM_Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Data.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TGHGBD6;Initial Catalog=CRM-DB;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //mapping işlemleri yapar
        {
            modelBuilder.HasDefaultSchema("dbo");


            modelBuilder.Entity<Pozisyon>(entity =>
            {
                entity.ToTable("Pozisyon");

                entity.Property(i => i.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseIdentityColumn()
                    .IsRequired();
                entity.Property(i => i.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
                entity.Property(i => i.Score)
                    .HasColumnName("Score")
                    .HasColumnType("int")
                    .IsRequired();
            });

            modelBuilder.Entity<Sektor>(entity =>
            {
                entity.ToTable("Sektor");

                entity.Property(i => i.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .UseIdentityColumn()
                    .IsRequired();
                entity.Property(i => i.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
                entity.Property(i => i.Group)
                    .HasColumnName("Group")
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
                entity.Property(i => i.Score)
                    .HasColumnName("Score")
                    .HasColumnType("int")
                    .IsRequired();
            });


            base.OnModelCreating(modelBuilder);
        }
    }


}
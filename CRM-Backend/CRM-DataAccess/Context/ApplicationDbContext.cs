using CRM_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DataAccess.Context
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
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TGHGBD6;Initial Catalog=CRM-DB;Integrated Security=True;TrustServerCertificate=True");
            }
            
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
                entity.Property(i => i.Password)
                    .HasColumnName("Password")
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
                entity.Property(i => i.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
                entity.Property(i => i.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
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
                entity.Property(i => i.SectorId).HasColumnName("SectorId");
                entity.Property(i => i.PositionId).HasColumnName("PositionId");
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

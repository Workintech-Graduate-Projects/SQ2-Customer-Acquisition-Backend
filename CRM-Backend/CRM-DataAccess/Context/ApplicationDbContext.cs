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

        public DbSet<Position> Positions { get; set; } //veritabanındaki pozisyon tablosuna erişebilmek için oluşturulan değişken.
                                                       //Bu tablo üzerinde değişiklik yapmak için bu değişken kullanılacak
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users {get; set;}
        public DbSet<Customer> Customers { get; set; }


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


            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Posiiton");

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
                    .HasColumnType("int")
                    .IsRequired();
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
                    .HasColumnType("int")
                    .IsRequired();
            });


            base.OnModelCreating(modelBuilder);
        }
    }


}

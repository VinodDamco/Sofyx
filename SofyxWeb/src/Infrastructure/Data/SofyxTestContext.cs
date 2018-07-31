using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SofyxWeb.ApplicationCore.Entities;

namespace SofyxWeb.Infrastructure.Data
{
    public partial class SofyxTestContext : DbContext
    {
        public SofyxTestContext()
        {
        }

        public SofyxTestContext(DbContextOptions<SofyxTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        //public virtual DbSet<Product> Product { get; set; }
        //public virtual DbSet<RetailerLocation> RetailerLocation { get; set; }
        //public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=172.29.100.85,49172\\SQL;Database=SofyxTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.Property(e => e.Name)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            //});

            //modelBuilder.Entity<RetailerLocation>(entity =>
            //{
            //    entity.HasKey(e => e.LocId);

            //    entity.Property(e => e.LocLat)
            //        .HasColumnName("LocLAT")
            //        .HasColumnType("decimal(18, 6)");

            //    entity.Property(e => e.LocLong)
            //        .HasColumnName("LocLONG")
            //        .HasColumnType("decimal(18, 6)");

            //    entity.Property(e => e.LocName).HasMaxLength(100);
            //});

            //modelBuilder.Entity<Users>(entity =>
            //{
            //    entity.HasKey(e => e.UserName);

            //    entity.Property(e => e.UserName)
            //        .HasMaxLength(100)
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CreateDate).HasColumnType("datetime");

            //    entity.Property(e => e.FirstName).HasMaxLength(100);

            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();

            //    entity.Property(e => e.LastName).HasMaxLength(100);
            //});
        }
    }
}

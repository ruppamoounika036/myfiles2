using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assign3.Models
{
    public partial class AMAZONDBContext : DbContext
    {
        public AMAZONDBContext()
        {
        }

        public AMAZONDBContext(DbContextOptions<AMAZONDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Pay> Pays { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=TGU1SER15;Initial Catalog=AMAZONDB;User Id=sa;Password=Dbase@1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("Pk_Customer");

                entity.ToTable("CUSTOMER");

                entity.Property(e => e.Cname)
                    .IsUnicode(false)
                    .HasColumnName("CName");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("ITEMS");

                entity.Property(e => e.Idiscount).HasColumnName("IDiscount");

                entity.Property(e => e.Iname)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("IName");

                entity.Property(e => e.Iprice)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("IPrice");

                entity.Property(e => e.Iquant).HasColumnName("IQuant");

                entity.Property(e => e.Isubtotal)
                    .HasColumnType("numeric(29, 0)")
                    .HasColumnName("ISubtotal")
                    .HasComputedColumnSql("([IPrice]*[IQuant])", false);

                entity.HasOne(d => d.OidNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Items");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("Pk_Orders");

                entity.ToTable("ORDERS");

                entity.Property(e => e.Otime)
                    .HasColumnType("datetime")
                    .HasColumnName("OTime");

                entity.Property(e => e.PackageName).IsUnicode(false);

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Orders");
            });

            modelBuilder.Entity<Pay>(entity =>
            {
                entity.ToTable("PAY");

                entity.Property(e => e.Payable).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Pays)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("Fk1_Pay");

                entity.HasOne(d => d.OidNavigation)
                    .WithMany(p => p.Pays)
                    .HasForeignKey(d => d.Oid)
                    .HasConstraintName("Fk2_Pay");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

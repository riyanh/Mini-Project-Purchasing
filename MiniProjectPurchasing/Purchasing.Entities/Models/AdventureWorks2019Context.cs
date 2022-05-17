using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class AdventureWorks2019Context : DbContext
    {
        public AdventureWorks2019Context()
        {
        }

        public AdventureWorks2019Context(DbContextOptions<AdventureWorks2019Context> options)
            : base(options)
        {
        }

        public virtual DbSet<vNewEditVendor> vNewEditVendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=divetri;Initial Catalog=AdventureWorks2019;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<vNewEditVendor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vNewEditVendor", "Purchasing");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.PurchasingWebServiceURL).HasMaxLength(1024);

                entity.Property(e => e.StandardPrice).HasColumnType("money");

                entity.Property(e => e.UnitMeasureCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

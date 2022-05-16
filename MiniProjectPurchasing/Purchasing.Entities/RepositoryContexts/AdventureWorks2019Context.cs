using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Purchasing.Entities.Models;

#nullable disable

namespace Purchasing.Entities.RepositoryContexts
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

        public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductVendor> ProductVendors { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public virtual DbSet<ShipMethod> ShipMethods { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<vVendorWithAddress> vVendorWithAddresses { get; set; }
        public virtual DbSet<vVendorWithContact> vVendorWithContacts { get; set; }
        public virtual DbSet<VListVendor> VListVendors { get; set; }
        public virtual DbSet<VProductReceipt> VProductReceipts { get; set; }
        public virtual DbSet<VApprovedVendor> VApprovedVendors { get; set; }
        public virtual DbSet<VStatusTotalOrder> VStatusTotalOrders { get; set; }
        public virtual DbSet<VTotalDueMonth> VTotalDueMonths { get; set; }


        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
              if (!optionsBuilder.IsConfigured)
              {
  #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                  optionsBuilder.UseSqlServer("Data Source=DESKTOP-0GRTEHQ\\SQLEXPRESS;Initial Catalog=AdventureWorks2019;Trusted_Connection=True");
              }
          }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<VTotalDueMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VTotalDueMonth");

                entity.Property(e => e.Months)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.TotalDue).HasColumnType("money");
            });

            modelBuilder.Entity<VApprovedVendor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VApprovedVendor");

                entity.Property(e => e.Vendor)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<VStatusTotalOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VStatusTotalOrder");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.StatusVendor)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BusinessEntity>(entity =>
            {
                entity.ToTable("BusinessEntity", "Person");

                entity.HasComment("Source of the ID that connects vendors, customers, and employees with address and contact information.");

                entity.HasIndex(e => e.rowguid, "AK_BusinessEntity_rowguid")
                    .IsUnique();

                entity.Property(e => e.BusinessEntityID).HasComment("Primary key for all customers, vendors, and employees.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.rowguid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Production");

                entity.HasComment("Products sold or used in the manfacturing of sold products.");

                entity.HasIndex(e => e.Name, "AK_Product_Name")
                    .IsUnique();

                entity.HasIndex(e => e.ProductNumber, "AK_Product_ProductNumber")
                    .IsUnique();

                entity.HasIndex(e => e.rowguid, "AK_Product_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductID).HasComment("Primary key for Product records.");

                entity.Property(e => e.Class)
                    .HasMaxLength(2)
                    .IsFixedLength(true)
                    .HasComment("H = High, M = Medium, L = Low");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasComment("Product color.");

                entity.Property(e => e.DaysToManufacture).HasComment("Number of days required to manufacture the product.");

                entity.Property(e => e.DiscontinuedDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was discontinued.");

                entity.Property(e => e.FinishedGoodsFlag)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 = Product is not a salable item. 1 = Product is salable.");

                entity.Property(e => e.ListPrice)
                    .HasColumnType("money")
                    .HasComment("Selling price.");

                entity.Property(e => e.MakeFlag)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Name of the product.");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(2)
                    .IsFixedLength(true)
                    .HasComment("R = Road, M = Mountain, T = Touring, S = Standard");

                entity.Property(e => e.ProductModelID).HasComment("Product is a member of this product model. Foreign key to ProductModel.ProductModelID.");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasComment("Unique product identification number.");

                entity.Property(e => e.ProductSubcategoryID).HasComment("Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. ");

                entity.Property(e => e.ReorderPoint).HasComment("Inventory level that triggers a purchase order or work order. ");

                entity.Property(e => e.SafetyStockLevel).HasComment("Minimum inventory quantity. ");

                entity.Property(e => e.SellEndDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was no longer available for sale.");

                entity.Property(e => e.SellStartDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was available for sale.");

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .HasComment("Product size.");

                entity.Property(e => e.SizeUnitMeasureCode)
                    .HasMaxLength(3)
                    .IsFixedLength(true)
                    .HasComment("Unit of measure for Size column.");

                entity.Property(e => e.StandardCost)
                    .HasColumnType("money")
                    .HasComment("Standard cost of the product.");

                entity.Property(e => e.Style)
                    .HasMaxLength(2)
                    .IsFixedLength(true)
                    .HasComment("W = Womens, M = Mens, U = Universal");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(8, 2)")
                    .HasComment("Product weight.");

                entity.Property(e => e.WeightUnitMeasureCode)
                    .HasMaxLength(3)
                    .IsFixedLength(true)
                    .HasComment("Unit of measure for Weight column.");

                entity.Property(e => e.rowguid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

                entity.HasOne(d => d.SizeUnitMeasureCodeNavigation)
                    .WithMany(p => p.ProductSizeUnitMeasureCodeNavigations)
                    .HasForeignKey(d => d.SizeUnitMeasureCode);

                entity.HasOne(d => d.WeightUnitMeasureCodeNavigation)
                    .WithMany(p => p.ProductWeightUnitMeasureCodeNavigations)
                    .HasForeignKey(d => d.WeightUnitMeasureCode);
            });

            modelBuilder.Entity<ProductVendor>(entity =>
            {
                entity.HasKey(e => new { e.ProductID, e.BusinessEntityID })
                    .HasName("PK_ProductVendor_ProductID_BusinessEntityID");

                entity.ToTable("ProductVendor", "Purchasing");

                entity.HasComment("Cross-reference table mapping vendors with the products they supply.");

                entity.HasIndex(e => e.BusinessEntityID, "IX_ProductVendor_BusinessEntityID");

                entity.HasIndex(e => e.UnitMeasureCode, "IX_ProductVendor_UnitMeasureCode");

                entity.Property(e => e.ProductID).HasComment("Primary key. Foreign key to Product.ProductID.");

                entity.Property(e => e.BusinessEntityID).HasComment("Primary key. Foreign key to Vendor.BusinessEntityID.");

                entity.Property(e => e.AverageLeadTime).HasComment("The average span of time (in days) between placing an order with the vendor and receiving the purchased product.");

                entity.Property(e => e.LastReceiptCost)
                    .HasColumnType("money")
                    .HasComment("The selling price when last purchased.");

                entity.Property(e => e.LastReceiptDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was last received by the vendor.");

                entity.Property(e => e.MaxOrderQty).HasComment("The minimum quantity that should be ordered.");

                entity.Property(e => e.MinOrderQty).HasComment("The maximum quantity that should be ordered.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.OnOrderQty).HasComment("The quantity currently on order.");

                entity.Property(e => e.StandardPrice)
                    .HasColumnType("money")
                    .HasComment("The vendor's usual selling price.");

                entity.Property(e => e.UnitMeasureCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true)
                    .HasComment("The product's unit of measure.");

                entity.HasOne(d => d.BusinessEntity)
                    .WithMany(p => p.ProductVendors)
                    .HasForeignKey(d => d.BusinessEntityID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVendors)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.UnitMeasureCodeNavigation)
                    .WithMany(p => p.ProductVendors)
                    .HasForeignKey(d => d.UnitMeasureCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseOrderID, e.PurchaseOrderDetailID })
                    .HasName("PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID");

                entity.ToTable("PurchaseOrderDetail", "Purchasing");

                entity.HasComment("Individual products associated with a specific purchase order. See PurchaseOrderHeader.");

                entity.HasIndex(e => e.ProductID, "IX_PurchaseOrderDetail_ProductID");

                entity.Property(e => e.PurchaseOrderID).HasComment("Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.");

                entity.Property(e => e.PurchaseOrderDetailID)
                    .ValueGeneratedOnAdd()
                    .HasComment("Primary key. One line number per purchased product.");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product is expected to be received.");

                entity.Property(e => e.LineTotal)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(isnull([OrderQty]*[UnitPrice],(0.00)))", false)
                    .HasComment("Per product subtotal. Computed as OrderQty * UnitPrice.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.OrderQty).HasComment("Quantity ordered.");

                entity.Property(e => e.ProductID).HasComment("Product identification number. Foreign key to Product.ProductID.");

                entity.Property(e => e.ReceivedQty)
                    .HasColumnType("decimal(8, 2)")
                    .HasComment("Quantity actually received from the vendor.");

                entity.Property(e => e.RejectedQty)
                    .HasColumnType("decimal(8, 2)")
                    .HasComment("Quantity rejected during inspection.");

                entity.Property(e => e.StockedQty)
                    .HasColumnType("decimal(9, 2)")
                    .HasComputedColumnSql("(isnull([ReceivedQty]-[RejectedQty],(0.00)))", false)
                    .HasComment("Quantity accepted into inventory. Computed as ReceivedQty - RejectedQty.");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasComment("Vendor's selling price of a single product.");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.PurchaseOrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PurchaseOrderHeader>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderID)
                    .HasName("PK_PurchaseOrderHeader_PurchaseOrderID");

                entity.ToTable("PurchaseOrderHeader", "Purchasing");

                entity.HasComment("General purchase order information. See PurchaseOrderDetail.");

                entity.HasIndex(e => e.EmployeeID, "IX_PurchaseOrderHeader_EmployeeID");

                entity.HasIndex(e => e.VendorID, "IX_PurchaseOrderHeader_VendorID");

                entity.Property(e => e.PurchaseOrderID).HasComment("Primary key.");

                entity.Property(e => e.EmployeeID).HasComment("Employee who created the purchase order. Foreign key to Employee.BusinessEntityID.");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))")
                    .HasComment("Shipping cost.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Purchase order creation date.");

                entity.Property(e => e.RevisionNumber).HasComment("Incremental number to track changes to the purchase order over time.");

                entity.Property(e => e.ShipDate)
                    .HasColumnType("datetime")
                    .HasComment("Estimated shipment date from the vendor.");

                entity.Property(e => e.ShipMethodID).HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.");

                entity.Property(e => e.Status)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Order current status. 1 = Pending; 2 = Approved; 3 = Rejected; 4 = Complete");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))")
                    .HasComment("Purchase order subtotal. Computed as SUM(PurchaseOrderDetail.LineTotal)for the appropriate PurchaseOrderID.");

                entity.Property(e => e.TaxAmt)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))")
                    .HasComment("Tax amount.");

                entity.Property(e => e.TotalDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", true)
                    .HasComment("Total due to vendor. Computed as Subtotal + TaxAmt + Freight.");

                entity.Property(e => e.VendorID).HasComment("Vendor with whom the purchase order is placed. Foreign key to Vendor.BusinessEntityID.");

                entity.HasOne(d => d.ShipMethod)
                    .WithMany(p => p.PurchaseOrderHeaders)
                    .HasForeignKey(d => d.ShipMethodID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.PurchaseOrderHeaders)
                    .HasForeignKey(d => d.VendorID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ShipMethod>(entity =>
            {
                entity.ToTable("ShipMethod", "Purchasing");

                entity.HasComment("Shipping company lookup table.");

                entity.HasIndex(e => e.Name, "AK_ShipMethod_Name")
                    .IsUnique();

                entity.HasIndex(e => e.rowguid, "AK_ShipMethod_rowguid")
                    .IsUnique();

                entity.Property(e => e.ShipMethodID).HasComment("Primary key for ShipMethod records.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Shipping company name.");

                entity.Property(e => e.ShipBase)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))")
                    .HasComment("Minimum shipping charge.");

                entity.Property(e => e.ShipRate)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))")
                    .HasComment("Shipping charge per pound.");

                entity.Property(e => e.rowguid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            });

            modelBuilder.Entity<UnitMeasure>(entity =>
            {
                entity.HasKey(e => e.UnitMeasureCode)
                    .HasName("PK_UnitMeasure_UnitMeasureCode");

                entity.ToTable("UnitMeasure", "Production");

                entity.HasComment("Unit of measure lookup table.");

                entity.HasIndex(e => e.Name, "AK_UnitMeasure_Name")
                    .IsUnique();

                entity.Property(e => e.UnitMeasureCode)
                    .HasMaxLength(3)
                    .IsFixedLength(true)
                    .HasComment("Primary key.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Unit of measure description.");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityID)
                    .HasName("PK_Vendor_BusinessEntityID");

                entity.ToTable("Vendor", "Purchasing");

                entity.HasComment("Companies from whom Adventure Works Cycles purchases parts or other goods.");

                entity.HasIndex(e => e.AccountNumber, "AK_Vendor_AccountNumber")
                    .IsUnique();

                entity.Property(e => e.BusinessEntityID)
                    .ValueGeneratedNever()
                    .HasComment("Primary key for Vendor records.  Foreign key to BusinessEntity.BusinessEntityID");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasComment("Vendor account (identification) number.");

                entity.Property(e => e.ActiveFlag)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 = Vendor no longer used. 1 = Vendor is actively used.");

                entity.Property(e => e.CreditRating).HasComment("1 = Superior, 2 = Excellent, 3 = Above average, 4 = Average, 5 = Below average");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Company name.");

                entity.Property(e => e.PreferredVendorStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.");

                entity.Property(e => e.PurchasingWebServiceURL)
                    .HasMaxLength(1024)
                    .HasComment("Vendor URL.");

                entity.HasOne(d => d.BusinessEntity)
                    .WithOne(p => p.Vendor)
                    .HasForeignKey<Vendor>(d => d.BusinessEntityID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<vVendorWithAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vVendorWithAddresses", "Purchasing");

                entity.HasComment("Vendor (company) names and addresses .");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.AddressLine2).HasMaxLength(60);

                entity.Property(e => e.AddressType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryRegionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.StateProvinceName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<vVendorWithContact>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vVendorWithContacts", "Purchasing");

                entity.HasComment("Vendor (company) names  and the names of vendor employees to contact.");

                entity.Property(e => e.ContactType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(25);

                entity.Property(e => e.PhoneNumberType).HasMaxLength(50);

                entity.Property(e => e.Suffix).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(8);
            });

            modelBuilder.Entity<VListVendor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VListVendor");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VProductReceipt>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VProductReceipt");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.LastReceiptCost).HasColumnType("money");

                entity.Property(e => e.LastReceiptDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StandardPrice).HasColumnType("money");

                entity.Property(e => e.UnitMeasureCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<ConfAestheticLine> ConfAestheticLines { get; set; }

    public virtual DbSet<ConfBu> ConfBus { get; set; }

    public virtual DbSet<ConfCategory> ConfCategories { get; set; }

    public virtual DbSet<ConfCompany> ConfCompanies { get; set; }

    public virtual DbSet<ConfInventoryStatus> ConfInventoryStatuses { get; set; }

    public virtual DbSet<ConfInventoryType> ConfInventoryTypes { get; set; }

    public virtual DbSet<ConfShop> ConfShops { get; set; }

    public virtual DbSet<ConfShopStorageLocation> ConfShopStorageLocations { get; set; }

    public virtual DbSet<ConfStockType> ConfStockTypes { get; set; }

    public virtual DbSet<ConfStorageLocation> ConfStorageLocations { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<InventoryShop> InventoryShops { get; set; }

    public virtual DbSet<InventoryShopUser> InventoryShopUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M3B7RPI\\SQLEXPRESS01;Initial Catalog=Inventory_Odx;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConfAestheticLine>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("CONF_AESTHETIC_LINE");

            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConfBu>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("CONF_BU");

            entity.HasIndex(e => e.Code, "SBUCODE").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Enabled).HasDefaultValue(true);
        });

        modelBuilder.Entity<ConfCategory>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("CONF_CATEGORY");

            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConfCompany>(entity =>
        {
            entity.HasKey(e => e.CompanySapcode).HasName("PK_IV_COMPANY");

            entity.ToTable("CONF_COMPANY");

            entity.HasIndex(e => e.CompanySapcode, "UQ_CONF_COMPANY_Sapcode").IsUnique();

            entity.Property(e => e.CompanySapcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Company_Sapcode");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TimezoneOffset).HasColumnName("Timezone_Offset");
        });

        modelBuilder.Entity<ConfInventoryStatus>(entity =>
        {
            entity.HasKey(e => e.InventoryStatusId).HasName("PK_IV_INVENTORYSTATUS");

            entity.ToTable("CONF_INVENTORY_STATUS");

            entity.Property(e => e.InventoryStatusId)
                .ValueGeneratedNever()
                .HasColumnName("InventoryStatus_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConfInventoryType>(entity =>
        {
            entity.HasKey(e => e.InventoryTypeId).HasName("PK_INVENTORYTYPE");

            entity.ToTable("CONF_INVENTORY_TYPE");

            entity.HasIndex(e => e.Description, "IX_INVENTORYTYPE_Description_UNIQUE").IsUnique();

            entity.Property(e => e.InventoryTypeId).HasColumnName("InventoryType_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConfShop>(entity =>
        {
            entity.HasKey(e => e.ShopSapcode).HasName("PK_IV_SHOP");

            entity.ToTable("CONF_SHOP");

            entity.HasIndex(e => e.ShopSapcode, "IX_IV_SHOP").HasFillFactor(90);

            entity.Property(e => e.ShopSapcode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Shop_Sapcode");
            entity.Property(e => e.Active).HasDefaultValue(1);
            entity.Property(e => e.CompanySapcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Company_Sapcode");
            entity.Property(e => e.Listino)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.TimezoneOffset).HasColumnName("Timezone_Offset");

            entity.HasOne(d => d.CompanySapcodeNavigation).WithMany(p => p.ConfShops)
                .HasForeignKey(d => d.CompanySapcode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SHOP_COMPANY");
        });

        modelBuilder.Entity<ConfShopStorageLocation>(entity =>
        {
            entity.HasKey(e => new { e.ShopSapcode, e.StorageLocationCode });

            entity.ToTable("CONF_SHOP_STORAGE_LOCATION");

            entity.Property(e => e.ShopSapcode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Shop_Sapcode");
            entity.Property(e => e.StorageLocationCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("StorageLocation_Code");
            entity.Property(e => e.Active).HasDefaultValue(true);

            entity.HasOne(d => d.ShopSapcodeNavigation).WithMany(p => p.ConfShopStorageLocations)
                .HasForeignKey(d => d.ShopSapcode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONF_SHOP_STORAGE_LOCATION_CONF_SHOP");

            entity.HasOne(d => d.StorageLocationCodeNavigation).WithMany(p => p.ConfShopStorageLocations)
                .HasForeignKey(d => d.StorageLocationCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONF_SHOP_STORAGE_LOCATION_CONF_STOCK_TYPE");
        });

        modelBuilder.Entity<ConfStockType>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("CONF_STOCK_TYPE");

            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConfStorageLocation>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("CONF_STORAGE_LOCATION");

            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.StockTypeCodes).WithMany(p => p.StorageLocationCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "ConfStorageLocationStockType",
                    r => r.HasOne<ConfStockType>().WithMany()
                        .HasForeignKey("StockTypeCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CONF_STORAGE_LOCATION__STOCK_TYPE_CONF_STOCK_TYPE"),
                    l => l.HasOne<ConfStorageLocation>().WithMany()
                        .HasForeignKey("StorageLocationCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CONF_STORAGE_LOCATION__STOCK_TYPE_CONF_STORAGE_LOCATION"),
                    j =>
                    {
                        j.HasKey("StorageLocationCode", "StockTypeCode");
                        j.ToTable("CONF_STORAGE_LOCATION__STOCK_TYPE");
                        j.IndexerProperty<string>("StorageLocationCode")
                            .HasMaxLength(4)
                            .IsUnicode(false)
                            .HasColumnName("StorageLocation_Code");
                        j.IndexerProperty<string>("StockTypeCode")
                            .HasMaxLength(4)
                            .IsUnicode(false)
                            .HasColumnName("StockType_Code");
                    });
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.IvId).HasName("PK_IV_INVENTORY");

            entity.ToTable("INVENTORY");

            entity.Property(e => e.IvId).HasColumnName("IV_ID");
            entity.Property(e => e.CompanySapcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Company_Sapcode");
            entity.Property(e => e.CreationDate).HasColumnName("Creation_Date");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EntryDate).HasColumnName("Entry_Date");
            entity.Property(e => e.InventoryStatusId)
                .HasDefaultValue(1)
                .HasColumnName("InventoryStatus_ID");
            entity.Property(e => e.InventoryTypeId).HasColumnName("InventoryType_ID");
            entity.Property(e => e.IsExcelUploadDisabled).HasColumnName("is_ExcelUpload_Disabled");
            entity.Property(e => e.LastTouchDate).HasColumnName("LastTouch_Date");
            entity.Property(e => e.LastTouchUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LastTouch_User");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.QuantityDefault)
                .HasDefaultValue(1)
                .HasColumnName("Quantity_Default");
            entity.Property(e => e.ReferenceDate).HasColumnName("Reference_Date");

            entity.HasOne(d => d.CompanySapcodeNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.CompanySapcode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INVENTORY_COMPANY");

            entity.HasOne(d => d.InventoryStatus).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.InventoryStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INVENTORY_CONF_INVENTORY_STATUS");

            entity.HasOne(d => d.InventoryType).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.InventoryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INVENTORY_INVENTORYTYPE");
        });

        modelBuilder.Entity<InventoryShop>(entity =>
        {
            entity.HasKey(e => new { e.IvId, e.ShopSapcode, e.StorageLocationCode });

            entity.ToTable("INVENTORY_SHOP");

            entity.Property(e => e.IvId).HasColumnName("IV_ID");
            entity.Property(e => e.ShopSapcode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Shop_Sapcode");
            entity.Property(e => e.StorageLocationCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("StorageLocation_Code");

            entity.HasOne(d => d.Iv).WithMany(p => p.InventoryShops)
                .HasForeignKey(d => d.IvId)
                .HasConstraintName("FK_IV_SHOP_INVENTORY_IV_INVENTORY");

            entity.HasOne(d => d.ConfShopStorageLocation).WithMany(p => p.InventoryShops)
                .HasForeignKey(d => new { d.ShopSapcode, d.StorageLocationCode })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INVENTORY_SHOP_CONF_SHOP");

            entity.HasMany(d => d.BuCodes).WithMany(p => p.InventoryShops)
                .UsingEntity<Dictionary<string, object>>(
                    "InventoryShopBu",
                    r => r.HasOne<ConfBu>().WithMany()
                        .HasForeignKey("BuCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_INVENTORY_SHOP_BU_CONF_BU"),
                    l => l.HasOne<InventoryShop>().WithMany()
                        .HasForeignKey("IvId", "ShopSapcode", "StorageLocationCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_INVENTORY_SHOP_BU_INVENTORY_SHOP"),
                    j =>
                    {
                        j.HasKey("IvId", "ShopSapcode", "StorageLocationCode", "BuCode");
                        j.ToTable("INVENTORY_SHOP_BU");
                        j.IndexerProperty<int>("IvId").HasColumnName("IV_ID");
                        j.IndexerProperty<string>("ShopSapcode")
                            .HasMaxLength(4)
                            .IsUnicode(false)
                            .HasColumnName("Shop_Sapcode");
                        j.IndexerProperty<string>("StorageLocationCode")
                            .HasMaxLength(4)
                            .IsUnicode(false)
                            .HasColumnName("StorageLocation_Code");
                        j.IndexerProperty<string>("BuCode")
                            .HasMaxLength(3)
                            .IsUnicode(false)
                            .HasColumnName("BU_Code");
                    });
        });

        modelBuilder.Entity<InventoryShopUser>(entity =>
        {
            entity.HasKey(e => new { e.IvId, e.ShopSapcode, e.StorageLocationCode, e.UserId }).HasName("PK_IV_USER_SHOP_INVENTORY");

            entity.ToTable("INVENTORY_SHOP_USER");

            entity.Property(e => e.IvId).HasColumnName("IV_ID");
            entity.Property(e => e.ShopSapcode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Shop_Sapcode");
            entity.Property(e => e.StorageLocationCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("StorageLocation_Code");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Iv).WithMany(p => p.InventoryShopUsers)
                .HasForeignKey(d => d.IvId)
                .HasConstraintName("FK_IV_USER_SHOP_INVENTORY_IV_INVENTORY");

            entity.HasOne(d => d.User).WithMany(p => p.InventoryShopUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INVENTORY_SHOP_USER_USER");

            entity.HasOne(d => d.InventoryShop).WithMany(p => p.InventoryShopUsers)
                .HasForeignKey(d => new { d.IvId, d.ShopSapcode, d.StorageLocationCode })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INVENTORY_SHOP_USER_CONF_SHOP");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

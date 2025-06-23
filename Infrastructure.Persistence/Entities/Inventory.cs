using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class Inventory
{
    public int IvId { get; set; }

    public string CompanySapcode { get; set; } = null!;

    public int InventoryTypeId { get; set; }

    public int InventoryStatusId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ReferenceDate { get; set; }

    public DateTime EntryDate { get; set; }

    public int QuantityDefault { get; set; }

    public bool IsExcelUploadDisabled { get; set; }

    public string? LastTouchUser { get; set; }

    public DateTime? LastTouchDate { get; set; }

    public virtual ConfCompany CompanySapcodeNavigation { get; set; } = null!;

    public virtual ICollection<InventoryShopUser> InventoryShopUsers { get; set; } = new List<InventoryShopUser>();

    public virtual ICollection<InventoryShop> InventoryShops { get; set; } = new List<InventoryShop>();

    public virtual ConfInventoryStatus InventoryStatus { get; set; } = null!;

    public virtual ConfInventoryType InventoryType { get; set; } = null!;
}

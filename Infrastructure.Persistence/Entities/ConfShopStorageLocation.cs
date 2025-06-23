using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class ConfShopStorageLocation
{
    public string ShopSapcode { get; set; } = null!;

    public string StorageLocationCode { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<InventoryShop> InventoryShops { get; set; } = new List<InventoryShop>();

    public virtual ConfShop ShopSapcodeNavigation { get; set; } = null!;

    public virtual ConfStorageLocation StorageLocationCodeNavigation { get; set; } = null!;
}

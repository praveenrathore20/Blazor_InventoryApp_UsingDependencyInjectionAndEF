using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class InventoryShopUser
{
    public int IvId { get; set; }

    public string ShopSapcode { get; set; } = null!;

    public string StorageLocationCode { get; set; } = null!;

    public long UserId { get; set; }

    public virtual InventoryShop InventoryShop { get; set; } = null!;

    public virtual Inventory Iv { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

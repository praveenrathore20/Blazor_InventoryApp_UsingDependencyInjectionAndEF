using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class InventoryShop
{
    public int IvId { get; set; }

    public string ShopSapcode { get; set; } = null!;

    public string StorageLocationCode { get; set; } = null!;

    public virtual ConfShopStorageLocation ConfShopStorageLocation { get; set; } = null!;

    public virtual ICollection<InventoryShopUser> InventoryShopUsers { get; set; } = new List<InventoryShopUser>();

    public virtual Inventory Iv { get; set; } = null!;

    public virtual ICollection<ConfBu> BuCodes { get; set; } = new List<ConfBu>();
}

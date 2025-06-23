using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<InventoryShopUser> InventoryShopUsers { get; set; } = new List<InventoryShopUser>();
}

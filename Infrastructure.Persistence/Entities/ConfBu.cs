using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class ConfBu
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Enabled { get; set; }

    public virtual ICollection<InventoryShop> InventoryShops { get; set; } = new List<InventoryShop>();
}

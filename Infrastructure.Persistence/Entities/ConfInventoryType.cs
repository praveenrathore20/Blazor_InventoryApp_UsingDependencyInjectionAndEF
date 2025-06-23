using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class ConfInventoryType
{
    public int InventoryTypeId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}

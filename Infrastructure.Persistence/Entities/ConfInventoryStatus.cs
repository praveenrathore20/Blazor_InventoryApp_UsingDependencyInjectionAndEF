using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class ConfInventoryStatus
{
    public int InventoryStatusId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}

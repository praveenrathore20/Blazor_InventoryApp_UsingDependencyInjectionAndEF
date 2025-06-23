using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class ConfCompany
{
    public string CompanySapcode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int TimezoneOffset { get; set; }

    public bool Dismissed { get; set; }

    public virtual ICollection<ConfShop> ConfShops { get; set; } = new List<ConfShop>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}

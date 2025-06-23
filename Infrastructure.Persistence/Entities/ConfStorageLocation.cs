using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class ConfStorageLocation
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<ConfShopStorageLocation> ConfShopStorageLocations { get; set; } = new List<ConfShopStorageLocation>();

    public virtual ICollection<ConfStockType> StockTypeCodes { get; set; } = new List<ConfStockType>();
}

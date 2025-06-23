using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class ConfStockType
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<ConfStorageLocation> StorageLocationCodes { get; set; } = new List<ConfStorageLocation>();
}

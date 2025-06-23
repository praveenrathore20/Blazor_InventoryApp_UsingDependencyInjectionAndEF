using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class ConfShop
{
    public string ShopSapcode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Listino { get; set; } = null!;

    public string CompanySapcode { get; set; } = null!;

    public int Active { get; set; }

    public int TimezoneOffset { get; set; }

    public virtual ConfCompany CompanySapcodeNavigation { get; set; } = null!;

    public virtual ICollection<ConfShopStorageLocation> ConfShopStorageLocations { get; set; } = new List<ConfShopStorageLocation>();
}

using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities;

public partial class ConfCategory
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;
}

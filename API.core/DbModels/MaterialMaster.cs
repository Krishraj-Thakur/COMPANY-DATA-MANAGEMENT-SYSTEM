using System;
using System.Collections.Generic;

namespace API.core.DbModels;

public partial class MaterialMaster
{
    public int MatId { get; set; }

    public string? MatDesc { get; set; }

    public string? MatPoText { get; set; }

    public double? Quantity { get; set; }

    public virtual ICollection<PritemDetail> PritemDetails { get; set; } = new List<PritemDetail>();
}

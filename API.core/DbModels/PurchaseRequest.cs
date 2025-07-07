using System;
using System.Collections.Generic;

namespace API.core.DbModels;

public partial class PurchaseRequest
{
    public int Id { get; set; }

    public int? RefNum { get; set; }

    public int Prtype { get; set; }

    public string? Company { get; set; }

    public string? PrComsumed { get; set; }

    public int? Currency { get; set; }

    public string? Remarks { get; set; }

    public virtual ICollection<PritemDetail> PritemDetails { get; set; } = new List<PritemDetail>();

    public virtual PurchaseType PrtypeNavigation { get; set; } = null!;
}

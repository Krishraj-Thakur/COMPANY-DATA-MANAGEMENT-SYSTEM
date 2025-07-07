using System;
using System.Collections.Generic;

namespace API.core.DbModels;

public partial class PurchaseType
{
    public int PrtypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = new List<PurchaseRequest>();
}

using System;
using System.Collections.Generic;

namespace API.core.DbModels;

public partial class PritemDetail
{
    public int Id { get; set; }

    public int PrId { get; set; }

    public int MatId { get; set; }

    public int? AvailableQuantity { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? CurrentStatus { get; set; }

    public virtual MaterialMaster MatCodeNavigation { get; set; } = null!;

    public virtual PurchaseRequest Pr { get; set; } = null!;
}

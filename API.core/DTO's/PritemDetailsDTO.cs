using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.core.DTO_s
{
    public class PritemDetailsDTO
    {
        
           // public int Id { get; set; }  // Refers to PurchaseRequest
          //  public int PrId { get; set; }  // Refers to PurchaseRequest
            public int MatId { get; set; }  // Refers to MaterialMaster
            public int AvailableQuantity { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string? CurrentStatus { get; set; }

        public MaterialMasterDTO? MaterialMaster { get; set; }

    }
}

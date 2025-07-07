using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.core.DTO_s
{
    public class PurchaseRequestsDTO
    {
        public int Id { get; set; }
        public int? RefNum { get; set; }
        public int? Prtype { get; set; }
        public string? Company { get; set; }
        public string? PrComsumed { get; set; }
        public int? Currency { get; set; }
        public string? Remarks { get; set; }
        // Navigation properties can be added if needed
         //public virtual PurchaseTypeDTO? PrtypeNavigation { get; set; }
         public virtual ICollection<PritemDetailsDTO>? PritemDetails { get; set; }
        public virtual PurchaseTypeDTO? PrtypeNavigation { get; set; }
    }
}

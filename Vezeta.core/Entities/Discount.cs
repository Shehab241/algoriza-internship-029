using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Enums;

namespace Vezeeta.Core.Entities
{
    public class Discount:BaseEntity
    {
        public int DiscountCode { get; set; }
        public DiscountType discountType { get; set; }
        public int value { get; set; }
        public ICollection<Patient> patients { get; set; } = new HashSet<Patient>();
    }
}

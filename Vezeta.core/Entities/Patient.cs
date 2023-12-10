using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Enums;

namespace Vezeeta.Core.Entities
{
    public class Patient:BaseEntity
    {
        public string FullName { get; set; }
        public string email { get; set; }
        public string Phone { get; set; }
        public gender Gender { get; set; }
        public string Image { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("User")]

        public string UserId { get; set; }

        public User User { get; set; }
        public ICollection<Discount> Discounts { get; set; } = new HashSet<Discount>();
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();


    }
}

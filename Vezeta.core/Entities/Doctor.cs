using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Enums;

namespace Vezeeta.Core.Entities
{
    public class Doctor:BaseEntity
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string email { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; } 
        public gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

        [ForeignKey("User")]
        public string? UserId { get; set; }
        [ForeignKey("Specialization")]
        public int? SpeciatizationId { get; set; }

        public Specialization Specialization { get; set; }

        public User User { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Enums;

namespace Vezeeta.Core.Entities
{
    public class Booking:BaseEntity
    {
        public Status status { get; set; }
        [ForeignKey("Patient")]
        public int? PatientId{ get; set; }
        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
       

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

    }
}

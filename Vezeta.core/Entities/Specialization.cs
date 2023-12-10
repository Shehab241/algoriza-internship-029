﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.Entities
{
    public class Specialization:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }=new HashSet<Doctor>();
    }
}

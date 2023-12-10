using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Core.Entities
{
    public class User:IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int UserId { get; set; }
        public string? Displayname { get; set; }
        public string? AccountType { get; set; }
        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }
    }

}

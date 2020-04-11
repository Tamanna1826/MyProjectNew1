using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BSKv5.Models
{
    public class Organizer
    {
        [Key]
        public int orgID { get; set; }
        [Required]
        public String orgName { get; set; }
        [Required]
        public String orgPhone { get; set; }
        [Required]
        public String orgEmail { get; set; }
        [Required]
        public String orgPassword { get; set; }

    }
}

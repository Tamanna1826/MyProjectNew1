using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BSKv5.Models
{
    public class Officer
    {
        [Key]
        public int ofID { get; set; }
        [Required]
        public string ofName { get; set; }
        [Required]
        public string ofEmail { get; set; }
        [Required]
        public string ofPassword { get; set; }
        
    }
}

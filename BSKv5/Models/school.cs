using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BSKv5.Models
{
    public class school
    {
        [Key]
        public int SchoolID { get; set; }
        [Required]
        public String SchoolCode { get; set; }
        [Required]
        public string SchoolName { get; set; }
        
       // [Foreign Key("orgID")]
        public int orgID { get; set; }

    }

}

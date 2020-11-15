using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LAB3.Models
{
    public class Rivers
    {
        [Key]
        public int RV_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string RV_NAME { get; set; }

      
        //public int RV_COUNTRY_ID { get; set; }

        //public ICollection<Countries> Countries { get; set; }
    }
}

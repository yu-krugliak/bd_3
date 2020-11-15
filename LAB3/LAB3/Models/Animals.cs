using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LAB3.Models
{
    public class Animals
    {
        [Key]
        public int AN_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string AN_NAME { get; set; }

        [Required]
        [Display(Name = "Height")]
        public double AN_HEIGHT { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public double AN_WEIGHT { get; set; }

        
    }
}

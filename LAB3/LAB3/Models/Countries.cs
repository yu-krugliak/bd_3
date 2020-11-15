using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace LAB3.Models
{
    public class Countries
    {
        [Key]
        public int CN_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string CN_NAME { get; set; }

        //public ICollection<Rivers> Rivers { get; set; }
    }
}

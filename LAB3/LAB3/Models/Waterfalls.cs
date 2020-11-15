using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LAB3.Models
{
    public class Waterfalls
    {
        [Key]
        public int WF_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string WF_NAME { get; set; }

        [Required]
        [Display(Name = "Height")]
        public int WF_HEIGHT { get; set; }

        //public int WF_RIVER_ID { get; set; }
        //pu/blic int WF_TYPE_ID { get; set; }


        //public ICollection<Rivers> Rivers { get; set; }

    }
}

   
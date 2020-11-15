using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace LAB3.Models
{
    public class Visits
    {
        [Key]
        public int VS_ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime VS_DATE { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Description")]
        public string VS_DESCRIPTION { get; set; }

        //public ICollection<Animals> Animals { get; set; }
        //public ICollection<Waterfalls> Waterfalls { get; set; }
    }
}

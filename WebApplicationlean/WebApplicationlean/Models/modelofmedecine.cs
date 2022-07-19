using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationlean.Models
{
    public class modelofmedecine
    {
        [Required]
        [DisplayName("Name of Medecine")]
        public String Nameofmed { get; set; }
        

        public int Parmasisid { get; set; }
        

        public String dateandtime { get; set; }
        [Required]

        public int priceperunit { get; set; }

        [Key]
        [Required]

        public int UID { get; set; }




    }
}
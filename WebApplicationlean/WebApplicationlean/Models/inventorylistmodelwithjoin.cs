using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationlean.Models
{
    public class inventorylistmodelwithjoin
    {

        public String  Medecine { get; set; }
        public String  Supplier { get; set; }

        [Required]
        [Display(Name = "supplier")]
        public int supid { get; set; }
        [Required]
        public String Customname { get; set; }


        [Required]
        [Display(Name = "medecine Name")]

        public int medid { get; set; }
        [Required]

        public int quantity { get; set; }
        [Required]

        public int priceperunit { get; set; }

        public int itemid { get; set; }
    }
}
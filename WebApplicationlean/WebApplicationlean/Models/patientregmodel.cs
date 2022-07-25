using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationlean.Models
{
    public class patientregmodel
    {
        [Required]
        public String Docid { get; set; }
        [Required]

        public String patientName { get; set; }
        [Required]

        public String DOB { get; set; }
        [Required]

        public String gender { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public String Phonenumber { get; set; }
        [Required]

        public String Address { get; set; }
        
        //public String Dateofbill { get; set; }

        public int Bid { get; set; }

        
    }
}
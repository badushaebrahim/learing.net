using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationlean.Models
{
    public class modelofsupplyer
    {
        [Required]
        public String  Supplyername { get; set; }
        [Required]
        public String Companyname { get; set; }
        [Required]
        public String  SupplyerAddress { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Email { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public String Phonenumber { get; set; }
        [Display(Name = "Date of Createion")]
        public String adddate { get; set; }

        public int SID { get; set; }
    }
}
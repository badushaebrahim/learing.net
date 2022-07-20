using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationlean.Models
{
    public class userloginmodel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
           public String Email { get; set; }
        [Required]
        public String Password { get; set; }

        public int ID { get; set; }
    }
}
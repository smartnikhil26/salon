using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salon1.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }
       
        public string Password { get; set; }
    }
}
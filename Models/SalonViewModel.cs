using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;

namespace Salon1.Models
{
    public class SalonViewModel
    {
        public int SalonId { get; set; }
        [Display(Name ="Salon Name")]
        public string SalonName { get; set; }
        public int AdminCount { get; set; }
        public int EmployeeCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
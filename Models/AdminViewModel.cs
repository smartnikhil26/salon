using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salon1.Models
{
    public class AdminViewModel
    {
        public int AdminId { get; set; }
        [Display(Name = "Admin Name")]
        public string AdminName { get; set; }
        [Display(Name = "Salon Name")]
        public string SalonName { get; set; }
        public int EmployeeCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salon1.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Salon Name")]
        public string SalonName { get; set; }
        public int CustomerCount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salon1.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Salon Name")]
        public string SalonName { get; set; }
        public int EmployeeCount { get; set; }
        
    }
}
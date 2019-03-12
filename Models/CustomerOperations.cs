using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salon1.Models
{
    public class CustomerOperations
    {
        private SalonEntities1 db = new SalonEntities1();

        public List<CustomerViewModel> GetCustomerData()
        {
            var allCustomer = db.Logins.Where(i => i.UserId == (int)UserType.Customer);

            List<CustomerViewModel> CustomerViewModellist = new List<CustomerViewModel>();
            foreach (var item in allCustomer)
            {
                CustomerViewModel s = new CustomerViewModel();
                
                s.CustomerId = item.LoginId;
                s.CustomerName = item.LoginName;
                s.SalonName = item.SalonData.SalonName;
                s.EmployeeCount = item.SalonData.Logins.Where(i => i.UserId == (int)UserType.Employee).Count();
                CustomerViewModellist.Add(s);
            }
            return CustomerViewModellist;
        }
    }
}
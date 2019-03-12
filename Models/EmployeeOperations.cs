using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salon1.Models
{
    public class EmployeeOperations
    {
        private SalonEntities2 db = new SalonEntities2();

        public List<EmployeeViewModel> GetEmployeeData()
        {
            var allEmployee = db.Logins.Where(i => i.UserId == (int)UserType.Employee);

            List<EmployeeViewModel> EmployeeViewModellist = new List<EmployeeViewModel>();
            foreach (var item in allEmployee)
            {
                EmployeeViewModel s = new EmployeeViewModel();
                s.SalonName = item.SalonData.SalonName;
                s.EmployeeId = item.LoginId;
                s.EmployeeName = item.LoginName ;
                s.SalonName = item.SalonData.SalonName;
                s.CustomerCount = item.SalonData.Logins.Where(i => i.UserId == (int)UserType.Customer).Count();
                EmployeeViewModellist.Add(s);
            }
            return EmployeeViewModellist;
        }
    }
}
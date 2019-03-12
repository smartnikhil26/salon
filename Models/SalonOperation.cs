using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salon1.Models
{
    public class SalonOperation
    {
        private SalonEntities1 db = new SalonEntities1();

        public List<SalonViewModel> GetSalonData()
        {
            var allsalon = db.SalonDatas.ToList();

            List<SalonViewModel> SalonViewModellist = new List<SalonViewModel>();
            foreach (var item in allsalon)
            {
                SalonViewModel s = new SalonViewModel();
                s.SalonName = item.SalonName;
                s.AdminCount = item.Logins.Where(i => i.UserId == (int)UserType.Admin).Count();
                s.EmployeeCount = item.Logins.Where(i => i.UserId == (int)UserType.Employee).Count();
                s.CustomerCount = item.Logins.Where(i => i.UserId == (int)UserType.Customer).Count();
                SalonViewModellist.Add(s);
            }
            return SalonViewModellist;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salon1.Models
{
    public class AdminOperations
    { 
    private SalonEntities1 db = new SalonEntities1();

    public List<AdminViewModel> GetAdminData()
    {
        var allAdmin= db.Logins.Where(i=>i.UserId == (int)UserType.Admin);

        List<AdminViewModel> AdminViewModellist = new List<AdminViewModel>();
        foreach (var item in allAdmin)
        {
                AdminViewModel s = new AdminViewModel();
            s.SalonName = item.SalonData.SalonName;
                s.AdminId = item.LoginId;
                s.AdminName = item.LoginName;
                s.EmployeeCount = item.SalonData.Logins.Where(i => i.UserId == (int)UserType.Employee).Count();
            s.CustomerCount =item.SalonData.Logins.Where(i => i.UserId == (int)UserType.Customer).Count();
            AdminViewModellist.Add(s);
        }
        return AdminViewModellist;
    }
}
}
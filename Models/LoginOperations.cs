using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Salon1.Models
{
    public class LoginOperations
    {
        private SalonEntities2 db = new SalonEntities2();
        public bool Login(LoginViewModel login)
        {
            var user = db.Logins.Where(i => i.LoginName == login.LoginName && i.Password == login.Password).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;

            }
        }

        public Login GetUserByName(string userName)
        {
            var user = db.Logins.Where(i => i.LoginName == userName).FirstOrDefault();
            return user;
            
        }
    }
}
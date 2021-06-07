using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShoppe.SL
{
    public class User
    {
        DAL.User u1 = new DAL.User();
        public bool CheckUser(Models.User u2)
        {
            bool b = u1.CheckUser(u2);
            return b;
        }
    }
}
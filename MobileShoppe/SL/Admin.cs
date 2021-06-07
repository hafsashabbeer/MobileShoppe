using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShoppe.SL
{
    public class Admin
    {
        DAL.Admin a = new DAL.Admin();
        public bool CheckAdmin(Models.Admin a1)
        {
            bool b = a.CheckAdmin(a1);
            return b;
        }
    }
}
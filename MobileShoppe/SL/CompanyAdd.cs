using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShoppe.SL
{
    public class CompanyAdd
    {
        public int DisplayCompanyId()
        {
            DAL.CompanyAdd c1 = new DAL.CompanyAdd();
            int i = c1.DisplayCompanyId();
            return i;
        }
        public int AddCompany(Models.CompanyAdd c2)
        {
            DAL.CompanyAdd c1 = new DAL.CompanyAdd();
            int i = c1.AddCompany(c2);
            return i;
        }
    }
}
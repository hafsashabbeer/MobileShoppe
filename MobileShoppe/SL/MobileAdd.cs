using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.SL
{
    public class MobileAdd
    {
        public List<SelectListItem> CompanyNames()
        {
            DAL.StockUpdate s1 = new DAL.StockUpdate();
            List<SelectListItem> CompanyItems = s1.CompanyNames();
            return CompanyItems;
        }
        public List<SelectListItem> ModelNumbers(int id)
        {
            DAL.StockUpdate s1 = new DAL.StockUpdate();
            List<SelectListItem> ModelItems = s1.ModelNumbers(id);
            return ModelItems;
        }
        public int AddMobile(Models.MobileAdd m2)
        {
            DAL.MobileAdd m1 = new DAL.MobileAdd();
            int i = m1.AddMobile(m2);
            return i;
        }
    }
}
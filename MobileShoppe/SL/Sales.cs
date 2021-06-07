using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.SL
{
    public class Sales
    {
        public List<SelectListItem> CompanyNames()
        {
            DAL.Sales s1 = new DAL.Sales();
            List<SelectListItem> CompanyItems = s1.CompanyNames();
            return CompanyItems;
        }
        public List<SelectListItem> ModelNumbers(int id)
        {
            DAL.Sales s1 = new DAL.Sales();
            List<SelectListItem> ModelItems = s1.ModelNumbers(id);
            return ModelItems;
        }
        public List<SelectListItem> IMEINumbers(int id)
        {
            DAL.Sales s1 = new DAL.Sales();
            List<SelectListItem> IMEIItems = s1.IMEINumbers(id);
            return IMEIItems;
        }
        public string DisplayCompanyName(Models.Sales s2)
        {
            DAL.Sales s1 = new DAL.Sales();
            string i = s1.DisplayCompanyName(s2);
            return i;
        }
        public string DisplayModelNumber(Models.Sales s2)
        {
            DAL.Sales s1 = new DAL.Sales();
            string i = s1.DisplayModelNumber(s2);
            return i;
        }
        public string DisplayIMEINO(Models.Sales s2)
        {
            DAL.Sales s1 = new DAL.Sales();
            string i = s1.DisplayIMEINO(s2);
            return i;
        }
        public string DisplayWarranty(Models.Sales s2)
        {
            DAL.Sales s1 = new DAL.Sales();
            string i = s1.DisplayWarranty(s2);
            return i;
        }
        public int AddSales(Models.Sales s1)
        {
            DAL.Sales s2 = new DAL.Sales();
            int i = s2.AddSales(s1);
            return i;
        }
    }
}
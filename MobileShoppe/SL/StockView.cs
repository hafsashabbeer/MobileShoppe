using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.SL
{
    public class StockView
    {
        public List<SelectListItem> CompanyNames()
        {
            DAL.StockView s1 = new DAL.StockView();
            List<SelectListItem> CompanyItems = s1.CompanyNames();
            return CompanyItems;
        }
        public List<SelectListItem> ModelNumbers(int id)
        {
            DAL.StockUpdate s1 = new DAL.StockUpdate();
            List<SelectListItem> ModelItems = s1.ModelNumbers(id);
            return ModelItems;
        }
        public int DisplayAvailableQuantity(Models.StockView s2)
        {
            DAL.StockView s1 = new DAL.StockView();
            int i = s1.DisplayAvailableQuantity(s2);
            return i;
        }
    }
}
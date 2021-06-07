using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.SL
{
    public class StockUpdate
    {
        public int DispalyTranId()
        {
            DAL.StockUpdate s1 = new DAL.StockUpdate();
            int i = s1.DisplayTranId();
            return i;
        }
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
        public int UpdateStock(Models.StockUpdate s1)
        {
            DAL.StockUpdate s2 = new DAL.StockUpdate();
            int i = s2.UpdateStock(s1);
            return i;
        }
        public int UpdateQuantity(Models.StockUpdate s1)
        {
            DAL.StockUpdate s2 = new DAL.StockUpdate();
            int i = s2.UpdateStock(s1);
            return i;
        }
    }
}
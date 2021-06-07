using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShoppe.SL
{
    public class Day
    {
        public List<Models.Day> SalesDetails(Models.Day d1)
        {
            DAL.Day d2 = new DAL.Day();
            List<Models.Day> SalesList = d2.SalesDetails(d1);
            return SalesList;
        }
        public int TotalSales(Models.Day d1)
        {
            DAL.Day d2 = new DAL.Day();
            int i = d2.TotalSales(d1);
            return i;
        }
    }
}
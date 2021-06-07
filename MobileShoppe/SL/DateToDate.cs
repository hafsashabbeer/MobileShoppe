using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShoppe.SL
{
    public class DateToDate
    {
        public List<Models.DateToDate> DisplayDetails(Models.DateToDate d1)
        {
            DAL.DateToDate d2 = new DAL.DateToDate();
            List<Models.DateToDate> SalesList = d2.DisplayDetails(d1);
            return SalesList;
        }
        public int TotalSales(Models.DateToDate d1)
        {
            DAL.DateToDate d2 = new DAL.DateToDate();
            int i = d2.TotalSales(d1);
            return i;
        }
    }
}
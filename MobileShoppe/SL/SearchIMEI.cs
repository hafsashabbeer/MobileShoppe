using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShoppe.SL
{
    public class SearchIMEI
    {
        public List<Models.SearchIMEI> DisplayCustomerDetails(Models.SearchIMEI s1)
        {
            DAL.SearchIMEI s2 = new DAL.SearchIMEI();
            List < Models.SearchIMEI > IMEIList = s2.DisplayCustomerDetails(s1);
            return IMEIList;
        }
    }
}
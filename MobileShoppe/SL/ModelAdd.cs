using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.SL
{
    public class ModelAdd
    {
        public int DisplayModelId()
        {
            DAL.ModelAdd m1 = new DAL.ModelAdd();
            int i = m1.DisplayModelId();
            return i;
        }
        public List<SelectListItem> CompanyName()
        {
            DAL.ModelAdd m1 = new DAL.ModelAdd();
            List<SelectListItem> CompanyItems = m1.CompanyNames();
            return CompanyItems;
        }
        public int AddModel(Models.ModelAdd m2)
        {
            DAL.ModelAdd m1 = new DAL.ModelAdd();
            int i = m1.AddModel(m2);
            return i;
        }
    }
}
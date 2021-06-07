using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.Models
{
    public class MobileAdd
    {
        public MobileAdd()
        {
            this.CompanyNames = new List<SelectListItem>();
            this.ModelNumbers = new List<SelectListItem>();
        }
        public List<SelectListItem> CompanyNames { get; set; }
        public List<SelectListItem> ModelNumbers { get; set; }
        public string IMEINO { get; set; }
        public int ModelId { get; set; }
        public int CompanyId { get; set; }
        public string Warranty { get; set; }
        public string Price { get; set; }
    }
}
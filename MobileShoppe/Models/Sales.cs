using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.Models
{
    public class Sales
    {
        public int CompanyId { get; set; }
        public int ModelId { get; set; }
        public Sales()
        {
            this.CompanyNames = new List<SelectListItem>();
            this.ModelNumbers = new List<SelectListItem>();
            this.IMEINO = new List<SelectListItem>();
        }
        public List<SelectListItem> CompanyNames { get; set; }
        public List<SelectListItem> ModelNumbers { get; set; }
        public List<SelectListItem> IMEINO { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string CompanyName { get; set; }
        public string ModelNumber { get; set; }
        public string IMEINum { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string PurchaseDate { get; set; }
        public string Price { get; set; }
        public string Warranty { get; set; }
    }
}
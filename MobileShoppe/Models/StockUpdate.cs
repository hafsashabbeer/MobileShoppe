using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.Models
{
    public class StockUpdate
    {
        public int TransactionId { get; set; }
        public StockUpdate()
        {
            this.CompanyNames = new List<SelectListItem>();
            this.ModelNumbers = new List<SelectListItem>();
        }
        public List<SelectListItem> CompanyNames { get; set; }
        public List<SelectListItem> ModelNumbers { get; set; }
        public int CompanyId { get; set; }
        public int ModelId { get; set; }
        public string Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }

    }
}
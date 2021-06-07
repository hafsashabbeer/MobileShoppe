using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.Models
{
    public class ModelAdd
    {
        public List<SelectListItem> CompanyNames { get; set; }
        public int CompanyId { get; set; }
        public int ModelId { get; set; }
        public string SelectedName { get; set; }
        public string ModelNumber { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
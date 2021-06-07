using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShoppe.Models
{
    public class Day
    {
        public DateTime SalesDay { get; set; }

        public int SalesId { get; set; }
        public string CompanyName { get; set; }
        public string ModelNumber { get; set; }
        public string IMEINO { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
}
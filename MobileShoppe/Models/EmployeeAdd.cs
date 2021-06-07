using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShoppe.Models
{
    public class EmployeeAdd
    {
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public string Hint { get; set; }
    }
}
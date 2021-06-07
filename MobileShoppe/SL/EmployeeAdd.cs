using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShoppe.SL
{
    public class EmployeeAdd
    {
        public int AddEmployee(Models.EmployeeAdd e1)
        {
            DAL.EmployeeAdd e2 = new DAL.EmployeeAdd();
            int i = e2.AddEmployee(e1);
            return i;
        }
        public string ForgetPassword(Models.EmployeeAdd e1)
        {
            DAL.EmployeeAdd e2 = new DAL.EmployeeAdd();
            string i = e2.ForgetPassword(e1);
            return i;
        }
    }
}
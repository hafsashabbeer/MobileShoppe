using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShoppe.Controllers
{

    public class HomeController : Controller
    {
        #region Employee
        
        [HttpGet]
        public ActionResult UserPage()
        {
            return View(); 
        }
        public ActionResult UserPage(Models.User s2)
        {
            SL.User u1 = new SL.User();
            bool b = u1.CheckUser(s2);
            if (b == false)
            {
                return RedirectToAction("EmployeeWelcome");
            }
            else
            {
                Response.Write("Invalid");
                return View();
            }
        }
        public ActionResult EmployeeWelcome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(Models.EmployeeAdd e1)
        {
            SL.EmployeeAdd e2 = new SL.EmployeeAdd();
            string i = e2.ForgetPassword(e1);
            TempData["Password"] = i;
            return View(e1);
        }

        public ActionResult Sales()
        {
            SL.Sales s1 = new SL.Sales();
            Models.Sales s2 = new Models.Sales();
            s2.CompanyNames = s1.CompanyNames();
            return View(s2);

        }
        public JsonResult GetModelNumbersForSales(int id)
        {
            SL.Sales s1 = new SL.Sales();
            List<SelectListItem> modelItems = s1.ModelNumbers(id);
            return Json(modelItems, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIMEINumbers(int id)
        {
            SL.Sales s1 = new SL.Sales();
            List<SelectListItem> IMEIItems = s1.IMEINumbers(id);
            return Json(IMEIItems, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Sales(Models.Sales s1) 
        {
            SL.Sales s2 = new SL.Sales();

            if(ModelState.IsValid)
            {
                Session["CustomerName"] = s1.CustomerName;
                Session["MobileNumber"] = s1.MobileNumber;
                Session["Address"] = s1.Address;
                Session["EmailId"] = s1.EmailId;
                Session["Price"] = s1.Price;
                Session["CompanyName"] = s2.DisplayCompanyName(s1);
                Session["ModelNumber"] = s2.DisplayModelNumber(s1);
                Session["IMEINum"] = s2.DisplayIMEINO(s1);
                Session["Warranty"] = s2.DisplayWarranty(s1);

                return RedirectToAction("Confirmation");
            }
            return RedirectToAction("s1");
        }
        [HttpGet]
        public ActionResult Confirmation()
        {
            Models.Sales s1 = new Models.Sales();
            s1.CustomerName = (string)Session["CustomerName"];
            s1.MobileNumber = (string)Session["MobileNumber"];
            s1.Address = (string)Session["Address"];
            s1.EmailId = (string)Session["EmailId"];
            s1.Price = (string)Session["Price"];
            s1.CompanyName = (string)Session["CompanyName"];
            s1.ModelNumber = (string)Session["ModelNumber"];
            s1.IMEINum = (string)Session["IMEINum"];
            s1.Warranty = (string)Session["Warranty"];
            return View(s1);
        }
        [HttpPost]
        public ActionResult Confirmation(Models.Sales s1)
        {
            s1.CustomerName = (string)Session["CustomerName"];
            s1.MobileNumber = (string)Session["MobileNumber"];
            s1.Address = (string)Session["Address"];
            s1.EmailId = (string)Session["EmailId"];
            s1.Price = (string)Session["Price"];
            s1.CompanyName = (string)Session["CompanyName"];
            s1.ModelNumber = (string)Session["ModelNumber"];
            s1.IMEINum = (string)Session["IMEINum"];
            s1.Warranty = (string)Session["Warranty"];
            SL.Sales s2 = new SL.Sales();
            int i = s2.AddSales(s1);
            if (i == 4)
            {
                TempData["message"] = "Sales Added";
                return RedirectToAction("Sales");
            }
            else
            {
                TempData["message"] = "Invalid";
                return RedirectToAction("Sales");
            }

        }

        [HttpGet]
        public ActionResult ViewStock()
        {
            SL.StockView s1 = new SL.StockView();
            Models.StockView s2 = new Models.StockView();
            s2.CompanyNames = s1.CompanyNames();
            return View(s2);
        }
        public JsonResult GetUserModelNumbers(int id)
        {
            SL.StockView s1 = new SL.StockView();
            List<SelectListItem> modelItems = s1.ModelNumbers(id);
            return Json(modelItems, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ViewStock(Models.StockView s1)
        {
            SL.StockView s2 = new SL.StockView();
            s1.StockAvailable = s2.DisplayAvailableQuantity(s1);
            TempData["AvailableStock"] = s1.StockAvailable;
            return View(s1);
        }

        [HttpGet]
        public ActionResult SearchCustomerDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchCustomerDetails(Models.SearchIMEI s1, string IMEI)
        {
            SL.SearchIMEI s2 = new SL.SearchIMEI();
            s1.IMEINO = IMEI;
            List<Models.SearchIMEI> IMEIList = s2.DisplayCustomerDetails(s1);
            return View(IMEIList);
        }
        #endregion

        #region Admin
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Admin(Models.Admin a2)
        {
            SL.Admin a1 = new SL.Admin();
            bool b = a1.CheckAdmin(a2);
            if(b == true)
            {
                return RedirectToAction("AdminWelcome");
            }
            else
            {
                Response.Write("Invalid");
                return View();
            }
        }
        public ActionResult AdminWelcome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCompany()
        {
            SL.CompanyAdd c1 = new SL.CompanyAdd();
            Models.CompanyAdd m1 = new Models.CompanyAdd();
            m1.CompanyId = c1.DisplayCompanyId();
            return View(m1);
        }
        public ActionResult AddCompany(Models.CompanyAdd c2)
        {
            SL.CompanyAdd c1 = new SL.CompanyAdd();
            int i = c1.AddCompany(c2);
            if (i == 1)
            {
                TempData["message"] = "Company Added";
                return RedirectToAction("AddCompany");
            }
            else
            {
                TempData["message"] = "Invalid";
                return RedirectToAction("AddCompany");
            }
        }
       
        
        [HttpGet]
        public ActionResult AddModel()
        {
            SL.ModelAdd m1 = new SL.ModelAdd();
            Models.ModelAdd m2 = new Models.ModelAdd();
            m2.ModelId = m1.DisplayModelId();
            m2.CompanyNames = m1.CompanyName();
            return View(m2);
        }
        [HttpPost]
        public ActionResult AddModel(Models.ModelAdd m2)
        {
            SL.ModelAdd m1 = new SL.ModelAdd();
            int i = m1.AddModel(m2);
            if (i == 1)
            {
                TempData["message"] = "Model Added";
                return RedirectToAction("AddModel");
            }
            else
            {
                TempData["message"] = "Invalid";
                return RedirectToAction("AddModel");
                
            }

        }

        [HttpGet]
        public ActionResult UpdateStock()
        {
            SL.StockUpdate s1 = new SL.StockUpdate();
            Models.StockUpdate s2 = new Models.StockUpdate();
            s2.TransactionId = s1.DispalyTranId();
            s2.CompanyNames = s1.CompanyNames();
            return View(s2);
        }
        public JsonResult GetModelNumbers(int id)
        {
            SL.StockUpdate s1 = new SL.StockUpdate();
            List<SelectListItem> modelItems = s1.ModelNumbers(id);
            return Json(modelItems, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateStock(Models.StockUpdate s1)
        {
            SL.StockUpdate s2 = new SL.StockUpdate();
            int i = s2.UpdateStock(s1);
            if (i == 2)
            {
                TempData["message"] = "Updated";
                return RedirectToAction("UpdateStock");
            }
            else
            {
                TempData["message"] = "Invalid";
                return RedirectToAction("UpdateStock");

            }
        }
        [HttpGet]
        public ActionResult AddMobile()
        {
            SL.MobileAdd s1 = new SL.MobileAdd();
            Models.MobileAdd s2 = new Models.MobileAdd();
            s2.CompanyNames = s1.CompanyNames();
            return View(s2);
        }
        public JsonResult GetModelNumbersForMobile(int id)
        {
            SL.StockUpdate s1 = new SL.StockUpdate();
            List<SelectListItem> modelItems = s1.ModelNumbers(id);
            return Json(modelItems, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddMobile(Models.MobileAdd s1)
        {
            SL.MobileAdd s2 = new SL.MobileAdd();
            int i = s2.AddMobile(s1);

            if(i == 1)
            {
                TempData["message"] = "Mobile Added";
                return RedirectToAction("AddMobile");
            }
            else
            {
                TempData["message"] = "Invalid";
                return RedirectToAction("AddMobile");
            }

        }
        [HttpGet]
        public ActionResult ViewSales()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Models.EmployeeAdd e1)
        {
            SL.EmployeeAdd e2 = new SL.EmployeeAdd();
            int i = e2.AddEmployee(e1);
            if (i == 1)
            {
                TempData["message"] = "Employee Added";
                return RedirectToAction("AddEmployee");
            }
            else
            {
                TempData["message"] = "Invalid";
                return RedirectToAction("AddEmployee");
            }
        }

        [HttpGet]
        public ActionResult Day()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Day(Models.Day d1, DateTime date)
        {
            SL.Day d2 = new SL.Day();
            d1.SalesDay = date;
            List<Models.Day> SalesList = d2.SalesDetails(d1);
            TempData["Total"] = d2.TotalSales(d1);
            return View(SalesList);
        }
        [HttpGet]
        public ActionResult DateToDate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DateToDate(Models.DateToDate d1, DateTime fromDate, DateTime tillDate)
        {
            SL.DateToDate d2 = new SL.DateToDate();
            d1.FromDate = fromDate;
            d1.TillDate = tillDate;
            List<Models.DateToDate> SalesList = d2.DisplayDetails(d1);
            TempData["Total"] = d2.TotalSales(d1);
            return View(SalesList);
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace MobileShoppe.DAL
{
    public class Sales
    {
        public int DisplayCustomerId()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SpGetCustId", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return i;
        }

        public List<SelectListItem> CompanyNames()
        {
            List<SelectListItem> CompanyItems = new List<SelectListItem>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CompanyId,CompanyName FROM Company", con);
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        CompanyItems.Add(new SelectListItem
                        {
                            Value = rdr["CompanyId"].ToString(),
                            Text = rdr["CompanyName"].ToString()
                        });
                    }
                }
            }
            return CompanyItems;
        }
        public List<SelectListItem> ModelNumbers(int id)
        {
            List<SelectListItem> ModelItems = new List<SelectListItem>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ModelId,ModelNum FROM Model WHERE CompanyId = @CompanyId", con);
                cmd.Parameters.AddWithValue("@CompanyId", id);
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            ModelItems.Add(new SelectListItem
                            {
                                Value = rdr["ModelId"].ToString(),
                                Text = rdr["ModelNum"].ToString()
                            });

                        }
                    }
            }
            return ModelItems;
        }
        public List<SelectListItem> IMEINumbers(int id)
        {
            List<SelectListItem> IMEIItems = new List<SelectListItem>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ModelId,IMEINO FROM Mobile WHERE ModelId = @ModelId", con);
                cmd.Parameters.AddWithValue("@ModelId", id);
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        IMEIItems.Add(new SelectListItem
                        {
                            Value = rdr["ModelId"].ToString(),
                            Text= rdr["IMEINO"].ToString()
                        });
                    }
                }
            }
            return IMEIItems;
        }

        public string DisplayCompanyName(Models.Sales s1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string i = null;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CompanyName FROM Company WHERE CompanyId = @CompanyId", con);
                cmd.Parameters.AddWithValue("@CompanyId",s1.CompanyId);

                i = Convert.ToString(cmd.ExecuteScalar());
            }
            return i;
        }
        public string DisplayModelNumber(Models.Sales s1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string i = null;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ModelNum FROM Model WHERE ModelId = @ModelId", con);
                cmd.Parameters.AddWithValue("@ModelId", s1.ModelId);

                i = Convert.ToString(cmd.ExecuteScalar());
            }
            return i;
        }
        public string DisplayIMEINO(Models.Sales s1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string i = null;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT IMEINO FROM Mobile WHERE ModelId = @ModelId", con);
                cmd.Parameters.AddWithValue("@ModelId", s1.ModelId);

                i = Convert.ToString(cmd.ExecuteScalar());
            }
            return i;
        }
        public string DisplayWarranty(Models.Sales s1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string i = null;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Warranty FROM Mobile WHERE IMEINO = @IMEINO", con);
                cmd.Parameters.AddWithValue("@IMEINO", DisplayIMEINO(s1));

                i = Convert.ToString(cmd.ExecuteScalar());
            }
            return i;
        }

        public int AddSales(Models.Sales s1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Customer (CustomerName, MobileNumber, EmailId,[Address]) " +
                    "VALUES (@CustomerName,@MobileNumber,@EmailId,@Address);" +
                    "DECLARE @Val INT SELECT @Val = CustomerId FROM Customer WHERE CustomerName = @CustomerName " +
                    "DECLARE @Date DATE SELECT @Date = GETDATE()"+
                    "INSERT INTO Sales (IMEINO,PurchaseDate,Price,CustomerId) " +
                    "VALUES(@IMEINO,@Date,@Price,@Val);"+
                    "UPDATE Mobile SET[Status] = 'Sold' WHERE IMEINO = @IMEINO;"+
                    "DECLARE @ModelId INT SELECT @ModelId = ModelId FROM Mobile WHERE IMEINO = @IMEINO " +
                    "UPDATE Model SET AvailableQty = AvailableQty - 1 WHERE ModelId = @ModelId", con) ;

                cmd.Parameters.AddWithValue("@CustomerName", s1.CustomerName);
                cmd.Parameters.AddWithValue("@MobileNumber", s1.MobileNumber);
                cmd.Parameters.AddWithValue("@EmailId", s1.EmailId);
                cmd.Parameters.AddWithValue("@Address", s1.Address);
                cmd.Parameters.AddWithValue("@IMEINO", s1.IMEINum);
                cmd.Parameters.AddWithValue("@Price", s1.Price);
                

                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace MobileShoppe.DAL
{
    public class StockView
    {
        public List<SelectListItem> CompanyNames()
        {
            List<SelectListItem> CompanyItems = new List<SelectListItem>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CompanyId,CompanyName FROM Company", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
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
            List<SelectListItem> modelItems = new List<SelectListItem>();
            Models.StockView s1 = new Models.StockView();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ModelId, ModelNum FROM Model WHERE CompanyId = @CompanyId", con);
                cmd.Parameters.AddWithValue("@CompanyId", id);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        modelItems.Add(new SelectListItem
                        {
                            Value = rdr["ModelId"].ToString(),
                            Text = rdr["ModelNum"].ToString()
                        });
                    }
                }
            }
            return modelItems;
        }
        public int DisplayAvailableQuantity(Models.StockView s1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT  AvailableQty FROM Model WHERE CompanyId = @CompanyId AND ModelId = @ModelId", con);
                cmd.Parameters.AddWithValue("@CompanyId", s1.CompanyId);
                cmd.Parameters.AddWithValue("@ModelId", s1.ModelId);
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return i;
        }
    }
}
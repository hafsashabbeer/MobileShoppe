using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace MobileShoppe.DAL
{
    public class MobileAdd
    {
        public List<SelectListItem> CompanyNames()
        {
            List<SelectListItem> CompanyItems = new List<SelectListItem>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
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
            Models.StockUpdate s1 = new Models.StockUpdate();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ModelId,ModelNum FROM Model WHERE CompanyId = @CompanyId", con);
                cmd.Parameters.AddWithValue("@CompanyId", id);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
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
        public int AddMobile(Models.MobileAdd m1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Mobile ( ModelId, IMEINO, Status, Warranty, Price ) VALUES" +
                                                "(@ModelId, @IMEINO, @Status, @Warranty, @Price)",con);

                cmd.Parameters.AddWithValue("@ModelId", m1.ModelId);
                cmd.Parameters.AddWithValue("@IMEINO", m1.IMEINO);
                cmd.Parameters.AddWithValue("@Status", "Not Sold");
                cmd.Parameters.AddWithValue("@Warranty", m1.Warranty);
                cmd.Parameters.AddWithValue("@Price", m1.Price);

                i = cmd.ExecuteNonQuery();

            }
            return i;
        }

    }
}
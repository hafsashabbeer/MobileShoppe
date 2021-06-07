using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace MobileShoppe.DAL
{
    public class StockUpdate
    {
        public int DisplayTranId()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SpGetTranId", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return i;
        }
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
            List<SelectListItem> ModelItems = new List<SelectListItem>();
            Models.StockUpdate s1 = new Models.StockUpdate();
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
        public int UpdateStock(Models.StockUpdate s1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [Transaction] (ModelId,Quantity,[Date],Amount)VALUES" +
                                                "(@ModelId, @Quantity, @Date, @Amount);" +
                                                "UPDATE Model SET AvailableQty = @Quantity " +
                                                "WHERE ModelId = @ModelId", con);
                cmd.Parameters.AddWithValue("@ModelId", s1.ModelId);
                cmd.Parameters.AddWithValue("@Quantity", s1.Quantity);
                cmd.Parameters.AddWithValue("@Date", s1.Date);
                cmd.Parameters.AddWithValue("@Amount", s1.Amount);


                i = cmd.ExecuteNonQuery();

            }
            return i;
        }
        //public int UpdateQuantity(Models.StockUpdate s1)
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    int i = 0;
        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("UPDATE Model " +
        //                                        "SET AvailableQty = @Quantity " +
        //                                        "WHERE ModelId = @ModelId", con);
        //        cmd.Parameters.AddWithValue("@Quantity", s1.Quantity);
        //        cmd.Parameters.AddWithValue("@ModelId", s1.ModelId);
               
        //        i = cmd.ExecuteNonQuery();

        //    }
        //    return i;
        //}
    }
}
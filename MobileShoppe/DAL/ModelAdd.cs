using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MobileShoppe.DAL
{
    public class ModelAdd
    {   
        public int DisplayModelId()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SpGetModelId", con);
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
                    while(rdr.Read())
                    {
                        CompanyItems.Add(new SelectListItem
                        {
                            Value = rdr["CompanyId"].ToString(),
                            Text = rdr["CompanyName"].ToString()
                        });
                        //CompanyItems.Add(rdr["CompanyName"].ToString());
                    }
                }

            }
            return CompanyItems;
        }
        public int AddModel(Models.ModelAdd m1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Model (CompanyId, ModelNum, AvailableQty) VALUES " +
                                                "(@CompanyId, @ModelNum, @AvailableQty)", con);
                //SqlCommand cmd = new SqlCommand("DECLARE @Id INT = (SELECT CompanyId FROM Company WHERE CompanyName = @CompanyName)" +
                //                                "INSERT INTO Model(CompanyId, ModelNum, AvailableQty) VALUES(@Id, @ModelNum, @AvailableQty)", con);

                cmd.Parameters.AddWithValue("@CompanyId", m1.CompanyId);
                cmd.Parameters.AddWithValue("@ModelNum", m1.ModelNumber);
                cmd.Parameters.AddWithValue("@AvailableQty", m1.AvailableQuantity);

                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}
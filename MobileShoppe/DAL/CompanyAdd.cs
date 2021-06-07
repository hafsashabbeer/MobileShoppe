using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MobileShoppe.DAL
{
    public class CompanyAdd
    {
        public int DisplayCompanyId()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SpGetCompanyId", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return i;
        }
        public int AddCompany(Models.CompanyAdd c1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AddCompany", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CompanyName", c1.CompanyName);

                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MobileShoppe.DAL
{
    public class Admin
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public bool CheckAdmin(Models.Admin l1)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CheckCredentials", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", l1.Username);
                cmd.Parameters.AddWithValue("@Password", l1.Password);

                bool b = Convert.ToBoolean(cmd.ExecuteScalar());
                return b;
            }
        }
    }
}
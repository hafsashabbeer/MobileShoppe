using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MobileShoppe.DAL
{
    public class EmployeeAdd
    {
        public int AddEmployee(Models.EmployeeAdd e1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using(SqlConnection con = new SqlConnection(CS))
            {
                if (e1.Password1 == e1.Password2)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO [User] (UserName, [Password], EmployeeName, [Address],MobileNumber, Hint, IsAdmin) " +
                        "VALUES(@UserName, @Password, @EmployeeName, @Address, @MobileNumber, @Hint, 0)", con);
                    cmd.Parameters.AddWithValue("@UserName", e1.UserName);
                    cmd.Parameters.AddWithValue("@Password", e1.Password1);
                    cmd.Parameters.AddWithValue("@EmployeeName", e1.EmployeeName);
                    cmd.Parameters.AddWithValue("@Address",e1.Address);
                    cmd.Parameters.AddWithValue("@MobileNumber", e1.Mobile);
                    cmd.Parameters.AddWithValue("@Hint", e1.Hint.ToUpper());

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public string ForgetPassword(Models.EmployeeAdd e1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string i = null;
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [Password] FROM [User] WHERE Hint = @Hint AND UserName = @UserName",con);
                cmd.Parameters.AddWithValue("@Hint", e1.Hint.ToUpper());
                cmd.Parameters.AddWithValue("@UserName", e1.UserName);
                i = (string)cmd.ExecuteScalar();
            }
            return i;
        }
    }
}
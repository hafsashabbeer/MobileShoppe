using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace MobileShoppe.DAL
{
    public class SearchIMEI
    {
        public List<Models.SearchIMEI> DisplayCustomerDetails(Models.SearchIMEI s1)
        {
            List<Models.SearchIMEI> IMEIList = new List<Models.SearchIMEI>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DECLARE @Id INT SELECT @Id = CustomerId FROM Sales WHERE IMEINO = @IMEINO " +
                    "SELECT CustomerName, MobileNumber, EmailId, [Address] FROM Customer WHERE CustomerId =@Id", con);
                cmd.Parameters.AddWithValue("@IMEINO",s1.IMEINO);

                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if(rdr.HasRows)
                    {
                        while(rdr.Read())
                        {
                            
                            s1.CustomerName = rdr["CustomerName"].ToString();
                            s1.MobileNumber = rdr["MobileNumber"].ToString();
                            s1.EmailId = rdr["EmailId"].ToString();
                            s1.Address = rdr["Address"].ToString();
                            IMEIList.Add(s1);
                        }
                    }

                }
            }
            return IMEIList;
        }
    }
}
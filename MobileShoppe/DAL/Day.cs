using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace MobileShoppe.DAL
{
    public class Day
    {
        public List<Models.Day> SalesDetails(Models.Day d1)
        {
            List<Models.Day> SalesList = new List<Models.Day>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT SalesId, CompanyName, Sales.IMEINO, ModelNum, Sales.Price FROM Model 
                                                INNER JOIN Company
                                                ON Model.CompanyId = Company.CompanyId
                                                INNER JOIN Mobile
                                                ON Model.ModelId = Mobile.ModelId
                                                INNER JOIN Sales
                                                ON Mobile.IMEINO = Sales.IMEINO
                                                WHERE PurchaseDate = @Date", con);

                cmd.Parameters.AddWithValue("@Date", d1.SalesDay);

                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if(rdr.HasRows)
                    {
                        while(rdr.Read())
                        {
                            Models.Day d2 = new Models.Day(); 
                            d2.SalesId = Convert.ToInt32(rdr["SalesId"]);
                            d2.ModelNumber = Convert.ToString(rdr["ModelNum"]);
                            d2.IMEINO = Convert.ToString(rdr["IMEINO"]);
                            d2.Price = Convert.ToInt32(rdr["Price"]);
                            d2.CompanyName = Convert.ToString(rdr["CompanyName"]);
                            SalesList.Add(d2);
                        }
                    }
                }
            }
            return SalesList;
        }
        public int TotalSales(Models.Day d1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(Price) AS Total FROM Sales WHERE PurchaseDate = @Date", con);
                cmd.Parameters.AddWithValue("@Date", d1.SalesDay);
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return i;
        }
    }
}
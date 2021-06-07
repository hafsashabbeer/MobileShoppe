using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace MobileShoppe.DAL
{
    public class DateToDate
    {
        public List<Models.DateToDate> DisplayDetails(Models.DateToDate d1)
        {
            List<Models.DateToDate> SalesList = new List<Models.DateToDate>();
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
                                                WHERE PurchaseDate >= @FromDate AND PurchaseDate <= @ToDate ", con);

                cmd.Parameters.AddWithValue("@FromDate", d1.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", d1.TillDate);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Models.DateToDate d2 = new Models.DateToDate();
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
        public int TotalSales(Models.DateToDate d1)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int i = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(Price) AS Total FROM Sales WHERE PurchaseDate >= @FromDate AND PurchaseDate <= @TillDate", con);
                cmd.Parameters.AddWithValue("@FromDate", d1.FromDate);
                cmd.Parameters.AddWithValue("@TillDate", d1.TillDate);
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return i;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AnnonsSystem.Models
{
    public class AdMethods
    {
        internal void CreateAd(AdDetails ad, out string errormsg)
        {
            //SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //koppling
            dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AnnonsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //sqlstring och lägg till en skribent i databasen
            String sqlstring = "INSERT INTO Tbl_Ads ( ad_Title, ad_Price, ad_Content, ad_AdPrice, ad_P_Annonsor, ad_F_Annonsor) " +
                "VALUES (@ad_Title, @ad_Price, @ad_Content, @ad_AdPrice, @ad_P_Annonsor, @ad_F_Annonsor)";

            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("ad_Title", SqlDbType.NVarChar, 20).Value = ad.ad_Title;
            dbCommand.Parameters.Add("ad_Price", SqlDbType.NVarChar, 20).Value = ad.ad_Price;
            dbCommand.Parameters.Add("ad_Content", SqlDbType.NVarChar, 20).Value = ad.ad_Content;
            dbCommand.Parameters.Add("ad_AdPrice", SqlDbType.NVarChar, 30).Value = ad.ad_AdPrice;
            dbCommand.Parameters.Add("ad_P_Annonsor", SqlDbType.NVarChar, 30).Value = ad.ad_P_Annonsor;
            dbCommand.Parameters.Add("ad_F_Annonsor", SqlDbType.NVarChar, 30).Value = ad.ad_F_Annonsor;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i != 0)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det skapades ingen avnändare";
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}

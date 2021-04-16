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

        public List<AdDetails> GetAdList(out string errormsg)
        {
            //SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //koppling
            dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AnnonsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            //sqlstring och lägg till en user i databasen
            String sqlstring = "SELECT * FROM Tbl_Ads";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //Skapa en adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
            DataSet myDS = new DataSet();

            List<AdDetails> AdList = new List<AdDetails>();


            try
            {
                dbConnection.Open();

                myAdapter.Fill(myDS, "Ads");
                int count = 0;
                int i = 0;

                count = myDS.Tables["Ads"].Rows.Count;

                if (count > 0)
                {
                    while (i < count)
                    {
                        AdDetails ad = new AdDetails();
                        ad.ad_Id = Convert.ToInt16(myDS.Tables["Ads"].Rows[i]["ad_Id"]);
                        ad.ad_Title = myDS.Tables["Ads"].Rows[i]["ad_Title"].ToString();
                        ad.ad_Price = Convert.ToInt16(myDS.Tables["Ads"].Rows[i]["ad_Price"]);
                        ad.ad_Content = myDS.Tables["Ads"].Rows[i]["ad_Content"].ToString();
                        ad.ad_P_Annonsor = Convert.ToInt16(myDS.Tables["Ads"].Rows[i]["ad_P_Annonsor"]);
                        ad.ad_F_Annonsor = Convert.ToInt16(myDS.Tables["Ads"].Rows[i]["ad_F_Annonsor"]);

                        i++;
                        AdList.Add(ad);
                    }
                    errormsg = "";
                    return AdList;
                }
                else
                {
                    errormsg = "no Ads, something went wrong";
                    return null;
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }

        }
    }
}

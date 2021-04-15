using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AnnonsSystem.Models
{
    public class AnnonsorMethods
    {
        public AnnonsorMethods() {}

        public int InsertAnnosor(AnnonsorDetails ad, out string errormsg)
        {
            //SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //koppling
            dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AnnonsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //sqlstring och lägg till en skribent i databasen
            String sqlstring = "INSERT INTO Tbl_Annonsorer (an_Namn, an_Tlfnr, an_OrgNr, an_Adress, an_Ort, an_PostNr, an_FkAdress, an_FkOrt, an_FkPostNr) " +
                "VALUES(@an_Namn, @an_Tlfnr, @an_OrgNr, @an_Adress, @an_Ort, @an_PostNr, @an_FkAdress, @an_FkOrt, @an_FkPostNr) SELECT SCOPE_IDENTITY()";

            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("an_Namn", SqlDbType.NVarChar, 20).Value = ad.an_Namn;
            dbCommand.Parameters.Add("an_Tlfnr", SqlDbType.NVarChar, 20).Value = ad.an_Tlfnr;
            dbCommand.Parameters.Add("an_OrgNr", SqlDbType.NVarChar, 20).Value = ad.an_OrgNr;
            dbCommand.Parameters.Add("an_Adress", SqlDbType.NVarChar, 30).Value = ad.an_Adress;
            dbCommand.Parameters.Add("an_Ort", SqlDbType.NVarChar, 30).Value = ad.an_Ort;
            dbCommand.Parameters.Add("an_PostNr", SqlDbType.NVarChar, 30).Value = ad.an_PostNr;
            dbCommand.Parameters.Add("an_FkAdress", SqlDbType.NVarChar, 30).Value = ad.an_FkAdress;
            dbCommand.Parameters.Add("an_FkOrt", SqlDbType.NVarChar, 30).Value = ad.an_FkOrt;
            dbCommand.Parameters.Add("an_FkPostNr", SqlDbType.NVarChar, 30).Value = ad.an_FkPostNr;


            try
            {
                dbConnection.Open();
                int i = 0;
                i = Convert.ToInt32(dbCommand.ExecuteScalar());
                if (i != 0)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det skapades ingen avnändare";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}

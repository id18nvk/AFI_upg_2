using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrenumerantSystem.Models
{
    public class PrenumerantMethods
    {

        public PrenumerantDetails GetPrenumerant(int pr_Id, out string errormsg)
        {
            //SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //koppling
            dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PrenumeranterDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //sqlstring och lägg till en skribent i databasen
            String sqlstring = "SELECT * FROM Tbl_Prenumeranter WHERE (pr_Id = @pr_Id)";

            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //Skapa en adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
            DataSet myDS = new DataSet();

            PrenumerantDetails pd = new PrenumerantDetails();

            dbCommand.Parameters.Add("pr_Id", SqlDbType.Int).Value = pr_Id;


            try
            {
                dbConnection.Open();

                myAdapter.Fill(myDS, "Prenumerant");
                int count = 0;
                int i = 0;

                count = myDS.Tables["Prenumerant"].Rows.Count;

                if (count > 0)
                {
                    pd.pr_Id = Convert.ToInt16(myDS.Tables["Prenumerant"].Rows[i]["pr_Id"]);
                    pd.pr_Firstname = myDS.Tables["Prenumerant"].Rows[i]["pr_Firstname"].ToString();
                    pd.pr_Lastname = myDS.Tables["Prenumerant"].Rows[i]["pr_Lastname"].ToString();
                    pd.pr_Tlfnr = myDS.Tables["Prenumerant"].Rows[i]["pr_Tlfnr"].ToString();
                    
                    pd.pr_Adress = myDS.Tables["Prenumerant"].Rows[i]["pr_Adress"].ToString();
                    pd.pr_Ort = myDS.Tables["Prenumerant"].Rows[i]["pr_Ort"].ToString();
                    pd.pr_PostNr = myDS.Tables["Prenumerant"].Rows[i]["pr_PostNr"].ToString();
                    
                    pd.pr_FkAdress = myDS.Tables["Prenumerant"].Rows[i]["pr_FkAdress"].ToString();
                    pd.pr_FkOrt = myDS.Tables["Prenumerant"].Rows[i]["pr_FkOrt"].ToString();
                    pd.pr_FkPostNr = myDS.Tables["Prenumerant"].Rows[i]["pr_FkPostNr"].ToString();


                    errormsg = "";
                    return pd;
                }
                else
                {
                    errormsg = "ingen med det id";
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

        
        
        
        
        //*******************UPDATE PRENUMERANT**********************
        public int UpdatePrenumerant(PrenumerantDetails pd, out string errormsg)
        {
            //SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //koppling
            dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PrenumeranterDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //sqlstring och lägg till en skribent i databasen
            String sqlstring = "UPDATE Tbl_Prenumeranter SET pr_Firstname = @pr_Firstname, pr_Lastname = @pr_Lastname, " +
                "pr_Tlfnr = @pr_Tlfnr, pr_Adress = @pr_Adress, pr_Ort = @pr_Ort, pr_PostNr = @pr_PostNr, pr_FkAdress = @pr_FkAdress, pr_FkOrt = @pr_FkOrt, pr_FkPostNr = @pr_FkPostNr WHERE pr_Id = @pr_Id";

            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("pr_Id", SqlDbType.Int).Value = pd.pr_Id;
            dbCommand.Parameters.Add("pr_Firstname", SqlDbType.NVarChar, 20).Value = pd.pr_Firstname;
            dbCommand.Parameters.Add("pr_Lastname", SqlDbType.NVarChar, 20).Value = pd.pr_Lastname;
            dbCommand.Parameters.Add("pr_Tlfnr", SqlDbType.NVarChar, 20).Value = pd.pr_Tlfnr;

            dbCommand.Parameters.Add("pr_Adress", SqlDbType.NVarChar, 30).Value = pd.pr_Adress;
            dbCommand.Parameters.Add("pr_Ort", SqlDbType.NVarChar, 30).Value = pd.pr_Ort;
            dbCommand.Parameters.Add("pr_PostNr", SqlDbType.NVarChar, 30).Value = pd.pr_PostNr;

            dbCommand.Parameters.Add("pr_FkAdress", SqlDbType.NVarChar, 30).Value = pd.pr_FkAdress;
            dbCommand.Parameters.Add("pr_FkOrt", SqlDbType.NVarChar, 30).Value = pd.pr_FkOrt;
            dbCommand.Parameters.Add("pr_FkPostNr", SqlDbType.NVarChar, 30).Value = pd.pr_FkPostNr;



            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();

                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "kunde inte ändra";
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
